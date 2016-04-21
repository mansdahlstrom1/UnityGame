using UnityEngine;
using System.Collections;

public class PlayerShip : MonoBehaviour {

    float timer;
    private InputHelper ip;
    private Vector3 startPos;
    private Vector3 endPos;
    private Quaternion startRotation;
    float rotateDeg = 0.0f;


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

    }

    public void move (string Direction)
    {
       

        if (Direction.Equals("up"))
        {
            endPos = new Vector3(startPos.x, startPos.y + (float) 0.1, startPos.z);   
        }

        if (Direction.Equals("down"))
        {
            endPos = new Vector3(startPos.x, startPos.y - (float) 0.1, startPos.z);
        }

        if (Direction.Equals("left"))
        {
            if (rotateDeg > -0.5f)
                rotateDeg += 0.02f;

 

            endPos = new Vector3(startPos.x - (float) 0.1, startPos.y, startPos.z);
        }

        if (Direction.Equals("right"))
        {
            if (rotateDeg < 0.5f)
                rotateDeg += 0.02f;

            endPos = new Vector3(startPos.x + (float) 0.1, startPos.y, startPos.z);

        }




        transform.position = Vector3.Lerp(startPos, endPos, Time.time - timer);
        transform.rotation = new Quaternion(startRotation.x , startRotation.y + rotateDeg  , startRotation.z, 0);
        //Debug.Log(rotateDeg);

        startPos = endPos;

        if (Direction.Equals("escape"))
        {
            string output = "startRotation.Y = " + startRotation.y + " Rotation.y right now = " + transform.rotation.y.ToString();
            Debug.Log(output);

        }
    }
}
