﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using System;

public class EnemyShip : Ship
{
    public Rect MoveArea;

    public int lives = 3;

    public int coins = 0;

    // Use this for initialization
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();

        velocity = new Vector2(moveSpeed, moveSpeed / 2);


        r2d.velocity = velocity;
    }
    void FixedUpdate()
    {
        Move();
        Shoot();
    }

    private void Move()
    {
        //Move the ship horizontally inside MoveArea
        if (velocity.x > 0 && transform.position.x > MoveArea.xMax)
        {
            velocity.x = moveSpeed * -1;

        }
        else if (velocity.x < 0 && transform.position.x < MoveArea.xMin)
        {
            velocity.x = moveSpeed;
        }
        //Move the ship vertically inside MoveArea
        if (velocity.y > 0 && transform.position.y > MoveArea.yMax)
        {
            velocity.y = (moveSpeed * -1) / 2;

        }
        else if (velocity.y < 0 && transform.position.y < MoveArea.yMin)
        {
            velocity.y = moveSpeed / 2;
        }


        r2d.velocity = velocity;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Missile"))
        {
            if (lives > 0)
                lives--;
            else
            {
                GameScript.coinsEarned += coins;
                Destroy(gameObject);
            }
        }
    }
}
