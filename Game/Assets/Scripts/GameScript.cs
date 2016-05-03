using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;
using System.Collections.Generic;

public class GameScript : MonoBehaviour {

    public int playerLives = 3;
    public int score = 0;
    GUIStyle labelStyle = new GUIStyle();
    public UnityEvent crashEvent;
    public List<PlayerShip> players;

    //public List<GameObject> playerships;


	// Use this for initialization
	void Start () {
        //PlayerShip p1 = GetComponent("StandardShip");
        //GameObject p1 = GameObject.FindGameObjectWithTag("OskarShip");
        //Debug.Log(p1.name);
        //players.Add(p1);


        labelStyle.border = new RectOffset(10, 10, 10, 10);


        foreach (PlayerShip ship in players)
        {
            ship.Crash += new PlayerShip.CollisionHandler(Crash);
        }

        labelStyle.fontSize = 22;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void FixedUpdate()
    {
        score++;
    }

    void OnGUI()
    {

        GUI.contentColor = Color.red;
        GUI.Label(new Rect(10, 10, 200, 22), "Lives: " + playerLives);
        GUI.Label(new Rect(10, 32, 200, 22), "Score: " + score);
    }

    void Crash(PlayerShip ship, GameObject obj, EventArgs e)
    {
        if (obj.name.Equals("Asteroid(Clone)"))
        {
            playerLives--;
        }
    }
}
