using UnityEngine;
using System.Collections;

public class InputHelper : MonoBehaviour {


    public PlayerShip ship;
    private string direction;
    private string oldKeyState;
    
    public InputHelper(PlayerShip sp)
    {
        ship = sp;
    }

    // Use this for initialization
    void Start () {

    }

    // Update is called once per frame
    public void CheckInput () {

        //if (oldKeyState != Input.inputString) { 
            if (Input.GetKey("w"))
            {
                direction = "up";
                ship.move(direction);
                Debug.Log("W");
            }
            if (Input.GetKey("a"))
            {
                direction = "left";
                ship.move(direction);
            }
            if (Input.GetKey("s"))
            {
                direction = "down";
                ship.move(direction);
            }
            if (Input.GetKey("d"))
            {
                direction = "right";
                ship.move(direction);
            }

            if (Input.GetKey("escape"))
            {
            // Test. Remove this later
            ship.move("escape");
            }
       // }

        oldKeyState = Input.inputString;
    }
}
