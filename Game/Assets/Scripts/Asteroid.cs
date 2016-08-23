using UnityEngine;
using System.Collections;
using System;

public class Asteroid : MonoBehaviour
{
    public float rotationSpeed;
    public float speed;
    public float SpeedIncreaseIntervalInSeconds;
    private float nextSpeedIncrease;

    private Rigidbody2D r2d;

    // Use this for initialization
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();

        r2d.velocity = new Vector2(0.0f, speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Time.time > nextSpeedIncrease)
        {
            nextSpeedIncrease = Time.time + SpeedIncreaseIntervalInSeconds;

            speed += speed / 2;
        }
        transform.Rotate(0, 0, rotationSpeed);
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
}
