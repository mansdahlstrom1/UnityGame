using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Events;
using Assets.Scripts;

public class PlayerShip : Ship
{
    private Rect shipBounds;
    private Rect cameraRect;
    
    public int playerNumber;

    private CharacterController characterController;

    public bool isInvulnerable;
    public float respawnTime;
    public float deathTime;
    
    //public int PlayerNumber { get { return playerNumber; } set { playerNumber = value; } }

    // Use this for initialization
    void Start()
    {
        characterController = GetComponent<CharacterController>();

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

    }

    // Update is called once per frame
    void Update()
    {
        //TEST
        //string joystickString = playerNumber.ToString();
        //velocity.x = Input.GetAxis("LeftJoystickX_P" + joystickString) * moveSpeed;
        //velocity.y = Input.GetAxis("LeftJoystickY_P" + joystickString) * moveSpeed;
        //TEST

        if (isInvulnerable)
        {
            if(Time.time > deathTime + respawnTime)
            {
                isInvulnerable = false;
            }
        }

        if (Input.GetButton("Fire"))
        {
            Shoot();
        }


        velocity.x = Input.GetAxis("Horizontal") * moveSpeed;
        velocity.y = Input.GetAxis("Vertical") * moveSpeed;

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
        else
        {
            if (transform.rotation.y > 0)
            {
                transform.Rotate(0, -2f, 0);
            }
            else if (transform.rotation.y < 0)
            {
                transform.Rotate(0, 2f, 0);
            }
        }

        r2d.velocity = velocity;

        transform.position = new Vector3(
           Mathf.Clamp(transform.position.x, (cameraRect.xMin + (shipBounds.width / 2)), (cameraRect.xMax - (shipBounds.width / 2))),
           Mathf.Clamp(transform.position.y, (cameraRect.yMin + (shipBounds.height / 2)), (cameraRect.yMax - (shipBounds.height / 2))),
           transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
        if (!isInvulnerable)
        {
            isInvulnerable = true;
            deathTime = Time.time;
        }
    }
}
