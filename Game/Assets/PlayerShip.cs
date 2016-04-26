using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerShip : MonoBehaviour {

    float timer;
    private InputHelper ip;
    private Vector3 startPos;
    private Vector3 endPos;
    private Quaternion startRotation;
    public float speed = 10;
    public float acceleration = 0.1f; 
    float rotateDeg = 0.0f;
    private string newKeyState = "";
    private string oldKeyState = "";

    private Missile missile;
    private int missileCount = 0;



    //private int x;
    //private int y;
    //public int X { get { return x; } set { x = value; } }
    //public int Y { get { return y; } set { y = value; } }

    // Use this for initialization
    void Start () {

        timer = Time.time;
        startPos = transform.position;
        endPos = new Vector3(2, 3, 2);
        ip = new InputHelper(this);
        startRotation = transform.rotation;
    }



    // Update is called once per frame
    void Update () {
        ip.CheckInput();
        if (rotateDeg < 0)
            rotateDeg += 0.01f;
        else 
        {
            rotateDeg -= 0.01f;
        }
        if (acceleration > 0.1f)
        {
            acceleration -= 0.01f;
        }

    }

    public void rotate(string Direction)
    {
        if (Direction.Equals("left")) {
            transform.Rotate(Vector3.forward * +1);
        }
    }

    public void Fire()
    {
        Debug.Log("Fire");
        
    }

    public void move (string Direction)
    {
        if (acceleration <= 1)
        {
            acceleration += 0.03f;
        } 

        float movementSpeed = acceleration * speed;
        if (Direction.Equals("up"))
        {
           
            endPos = new Vector3(startPos.x, startPos.y + movementSpeed, startPos.z);   
        }

        if (Direction.Equals("down"))
        {
            endPos = new Vector3(startPos.x, startPos.y - movementSpeed, startPos.z);
        }

        if (Direction.Equals("left"))
        {
            endPos = new Vector3(startPos.x - movementSpeed, startPos.y, startPos.z);
        }

        if (Direction.Equals("right"))
        {

            endPos = new Vector3(startPos.x + movementSpeed, startPos.y, startPos.z);

        }



        transform.position = Vector3.Lerp(startPos, endPos, Time.time - timer);

        startPos = endPos;

        oldKeyState = Direction;

    }
}
