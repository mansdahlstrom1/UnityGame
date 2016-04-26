using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerShip : MonoBehaviour
{

    private Rigidbody2D r2d;
    private Vector2 velocity = new Vector2(0.0f, 0.0f);

    public GameObject missile;
    public Transform missileSpawn;
    public float fireRate;
    public int moveSpeed;

    private float nextFire = 0.0f;

    private int playerNumber = 1;
    public int PlayerNumber {  get { return playerNumber; } set { playerNumber = value; } }
    
    // Use this for initialization
    void Start()
    {
        r2d = GetComponent<Rigidbody2D>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire") && Time.time > nextFire)
        {   
            nextFire = Time.time + fireRate;
            Instantiate(missile, missileSpawn.position, missileSpawn.rotation);
        }

        velocity.x = Input.GetAxis("Horizontal") * moveSpeed;
        velocity.y = Input.GetAxis("Vertical") * moveSpeed;

    }

}
