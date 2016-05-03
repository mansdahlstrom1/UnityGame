using UnityEngine;
using System.Collections;
using System;

public class Missile : MonoBehaviour
{
    public float speed;
    public Vector3 rotation;

    private PlayerShip myShip;
    private Rigidbody2D r2d;

    // Use this for initialization
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
        r2d.velocity = new Vector2(0.0f, speed);
    }

    public void Init(PlayerShip ship)
    {
        myShip = ship;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        transform.Rotate(rotation);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
