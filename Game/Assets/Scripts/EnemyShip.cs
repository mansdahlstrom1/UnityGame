using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;

public class EnemyShip : Ship
{
    public Rect MoveArea;

    // Use this for initialization
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();

        velocity = new Vector2(moveSpeed, moveSpeed / 2);


        r2d.velocity = velocity;
    }

    // Update is called once per frame
    void Update()
    {

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
        if (col.gameObject.tag.Equals("Missile") || col.gameObject.tag.Equals("Player"))
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        //Destroy(gameObject);
    }
}
