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
    private float deathTime;

    //Public Members
    public int playerNumber;
    public float respawnTime;

    //Properties
    private bool isInvulnerable;
    public bool IsInvulnerable {  get { return isInvulnerable; } set { isInvulnerable = value; } }

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

    }

    // Update is called once per frame
    void Update()
    {
        //Keep ship within camera
        if (isActive)
        {
            if (isInvulnerable)
            {
                if (Time.time > deathTime + respawnTime)
                {
                    isInvulnerable = false;
                }
            }

            if (Input.GetButton("Fire_P" + playerNumber))
            {
                Shoot();
            }


            velocity.x = Input.GetAxis("Horizontal_P" + playerNumber) * moveSpeed;
            velocity.y = Input.GetAxis("Vertical_P" + playerNumber) * moveSpeed;

            r2d.velocity = velocity;

            //Rotation
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

            transform.position = new Vector3(
               Mathf.Clamp(transform.position.x, (cameraRect.xMin + (shipBounds.width / 2)), (cameraRect.xMax - (shipBounds.width / 2))),
               Mathf.Clamp(transform.position.y, (cameraRect.yMin + (shipBounds.height / 2)), (cameraRect.yMax - (shipBounds.height / 2))),
               transform.position.z);
        }
    }

    new void OnTriggerEnter2D(Collider2D col)
    {
        base.OnTriggerEnter2D(col);
        
        if (!isInvulnerable && col.gameObject.tag.Equals("Enemy"))
        {
            isInvulnerable = true;
            deathTime = Time.time;
        }
    }
}
