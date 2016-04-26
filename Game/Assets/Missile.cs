using UnityEngine;
using System.Collections;

public class Missile : ScriptableObject
{
    float timer;
    private Vector3 startPos;
    private Vector3 endPos;
    private float acceleration = 0.1f;
    public float speed = 10;
    private PlayerShip myShip;


    public Missile(PlayerShip ship)
    {
        myShip = ship;
        startPos = myShip.transform.position;
        acceleration = 0.1f;
    }

    // Use this for initialization
    void Start()
    {
        timer = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (acceleration <= 1)
        {
            acceleration += 0.01f;
        }

        float movementSpeed = acceleration * speed;

        endPos = new Vector3(startPos.x, startPos.y + movementSpeed, startPos.z);

        //transform.position = Vector3.Lerp(startPos, endPos, Time.time - timer);

        startPos = endPos;
    }
}
