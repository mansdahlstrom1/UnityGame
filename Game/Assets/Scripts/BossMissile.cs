using UnityEngine;
using System.Collections;
using System;

public class BossMissile : MonoBehaviour
{
    public float rotationSpeed;
    public float speed;

    private Rigidbody2D r2d;

    public PlayerShip target;
    public float TargetCooldown;
    private float nextTargetCheck;

    private GameObject[] playerShips;

    // Use this for initialization
    void Start()
    {
        speed = -speed;

        r2d = GetComponent<Rigidbody2D>();

        r2d.velocity = new Vector2(0.0f, speed);

        playerShips = GameObject.FindGameObjectsWithTag("Player");

        target = playerShips[0].GetComponent<PlayerShip>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Find the closest player ship and make it the target.
        if (Time.time > nextTargetCheck)
        {
            nextTargetCheck = Time.time + this.TargetCooldown;
            
            //if we found a new target then change rotation direction
            if (FindTarget()) //FindTarget finds a new target and returns true if the target has changed
                rotationSpeed *= -1; 
            
            //Should I move right or left?
            if (this.transform.position.x > target.transform.position.x)
                r2d.velocity = new Vector2(speed, speed);
            else
                r2d.velocity = new Vector2(-speed / 2, speed);
        }


        //Rotate
        transform.Rotate(Vector3.forward * rotationSpeed);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Missile"))
        {
            Destroy(gameObject);
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private bool FindTarget()
    {
        PlayerShip previousTarget = target;
        foreach (var ship in playerShips)
        {
            if (this.transform.position.y < ship.transform.position.y)
            {
                var distanceToShip = Vector2.Distance(this.transform.position, ship.transform.position);
                var distanceToTarget = Vector2.Distance(this.transform.position, target.transform.position);

                if (distanceToTarget > distanceToShip)
                    target = ship.GetComponent<PlayerShip>();
            }
        }

        if (target == previousTarget)
            return false;
        else
            return true;
    }
}
