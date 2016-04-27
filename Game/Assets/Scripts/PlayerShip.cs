using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerShip : MonoBehaviour
{

    private Rigidbody2D r2d;
    public Vector2 velocity = new Vector2(0.0f, 0.0f);
    public GameObject missile;
    public Transform missileSpawn;
    public float fireRate;
    public int moveSpeed;
    public Rect shipBounds;
    public Rect cameraRect;

    private float nextFire = 0.0f;

    private int playerNumber = 1;
    public int PlayerNumber { get { return playerNumber; } set { playerNumber = value; } }

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
        if (Input.GetButton("Fire") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            Instantiate(missile, missileSpawn.position, missileSpawn.rotation);
        }


        velocity.x = Input.GetAxis("Horizontal") * moveSpeed;
        velocity.y = Input.GetAxis("Vertical") * moveSpeed;

        if (velocity.x > 0)
        {
            if (transform.rotation.y < 0.3)
                transform.Rotate(0, 1f, 0);
        }
        else if (velocity.x < 0 && transform.rotation.y > -0.3)
        {
            transform.Rotate(0, -2.5f, 0);
        }
        else
        {
            if (transform.rotation.y > 0)
            {
                transform.Rotate(0, -0.5f, 0);
            }
            else if (transform.rotation.y > 0)
            {
                transform.Rotate(0, 0.5f, 0);
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

        if (col.gameObject.name == "Meteroid(Clone)")
        {
            transform.position = new Vector3(0, -300);
        }
    }
}
