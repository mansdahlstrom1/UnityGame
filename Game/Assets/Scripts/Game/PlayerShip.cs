using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Events;
using Assets.Scripts;

public class PlayerShip : Ship
{
    //Private Members
    private Rect shipBounds;
    private Rect cameraRect;
    private float deathTime = 0.0f;
    private float lastRoll = 0.0f;

    //Public Members
    public int PlayerNumber;
    public float RespawnTime = 1.5f;
    public float RollForce = 2000;
    public float RollCooldown = 0.5f;
    public GameObject shield;

    public static int lives;

    public bool ShopMode;
    public bool Disabled;


    // To match DB
    public int cost;

    //Properties
    private bool isInvulnerable;
    public bool IsInvulnerable { get { return isInvulnerable; } set { isInvulnerable = value; } }

    // Use this for initialization
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();

        Renderer renderer = GetComponent<Renderer>();
        shipBounds = new Rect(
            transform.position.x,
            transform.position.y,
            renderer.bounds.size.x,
            renderer.bounds.size.y
        );

        Vector3 bottomLeft = Camera.main.ScreenToWorldPoint(Vector3.zero);
        Vector3 topRight = Camera.main.ScreenToWorldPoint(new Vector3(
            Camera.main.pixelWidth, Camera.main.pixelHeight));

        cameraRect = new Rect(
            bottomLeft.x,
            bottomLeft.y,
            topRight.x - bottomLeft.x,
            topRight.y - bottomLeft.y
        );

        shield = Instantiate(shield, transform.position, Quaternion.identity) as GameObject;
        shield.GetComponent<Renderer>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Disabled)
            return;

        if (isInvulnerable)
        {
            shield.GetComponent<Renderer>().enabled = true; //Show the blue shield
            if (Time.time > deathTime + RespawnTime)
            {
                shield.GetComponent<Renderer>().enabled = false;
                isInvulnerable = false;
            }
        }

        //Horizontal and vertical
        velocity.x += Input.GetAxis("Horizontal_P" + PlayerNumber) * moveSpeed;
        velocity.y += Input.GetAxis("Vertical_P" + PlayerNumber) * moveSpeed;


        //Input
        //Shoot
        if (Input.GetAxis("Fire_P" + PlayerNumber) > 0)
            Shoot();
        //else?
        //Roll

        if (Input.GetAxis("Roll_P" + PlayerNumber) != 0)
        {
            if (Time.time > lastRoll + RollCooldown)
            {
                lastRoll = Time.time;

                if (velocity.x > 0)
                    velocity += new Vector2(RollForce * moveSpeed, 0);
                else if (velocity.x < 0)
                    velocity -= new Vector2(RollForce * moveSpeed, 0);

            }
        }

        //Rotate
        Rotate(velocity);

        //Move
        r2d.velocity = velocity;
        velocity = new Vector2();
        //Move shield
        shield.transform.position = transform.position;

        //Keep player within camera
        transform.position = new Vector3(
           Mathf.Clamp(transform.position.x, (cameraRect.xMin + (shipBounds.width / 2)), (cameraRect.xMax - (shipBounds.width / 2))),
           Mathf.Clamp(transform.position.y, (cameraRect.yMin + (shipBounds.height / 2)), (cameraRect.yMax - (shipBounds.height / 2))),
           transform.position.z);
    }

    void Rotate(Vector2 velocity)
    {
        //Rotation based on velocity
        if (velocity.x > 0)
        {
            if (transform.rotation.y < 0.4)
                transform.Rotate(0, 2.5f, 0);
        }
        else if (velocity.x < 0)
        {
            if (transform.rotation.y > -0.4)
                transform.Rotate(0, -2.5f, 0);
        }
        else //Rotate back to normal position
        {
            if (transform.rotation.y > 0)
                transform.Rotate(0, -2f, 0);
            else if (transform.rotation.y < 0)
                transform.Rotate(0, 2f, 0);
        }
    }

    //Collision
    protected void OnTriggerEnter2D(Collider2D col)
    {
        //If the shield is down and you're colliding with an enemy
        if (!isInvulnerable && col.gameObject.tag.Equals("Enemy"))
        {
            PlayerShip.lives--;
            isInvulnerable = true;
            deathTime = Time.time;
        }
    }

}
