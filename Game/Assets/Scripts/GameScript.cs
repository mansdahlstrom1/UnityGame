using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;
using System.Collections.Generic;
using Assets.Scripts;

public class GameScript : MonoBehaviour
{

    //Game Logic
    public int playerLives = 3;
    public int score = 0;

    //GUI
    GUIStyle labelStyle = new GUIStyle();

    //?
    //public UnityEvent crashEvent;

    //Player
    public List<PlayerShip> players;
    //public List<GameObject> playerships;


    //Asteroid
    public GameObject asteroid;
    public float asteroidSpawnRate;
    private float asteroidNextSpawn;

    //Enemy
    public GameObject enemy;
    public float enemySpawnRate;
    private float enemyNextSpawn;

    // Use this for initialization
    void Start()
    {
        //PlayerShip p1 = GetComponent("StandardShip");
        //GameObject p1 = GameObject.FindGameObjectWithTag("OskarShip");
        //Debug.Log(p1.name);
        //players.Add(p1);


        labelStyle.border = new RectOffset(10, 10, 10, 10);


        foreach (PlayerShip ship in players)
        {
            ship.collisionEvent += new Ship.CollisionEvent(CollisionHandler);
        }

        labelStyle.fontSize = 22;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        SpawnEnemies();
        SpawnAsteroids();
        score++;
    }

    private void SpawnEnemies()
    {
        if (Time.time > enemyNextSpawn)
        {
            enemyNextSpawn = Time.time + enemySpawnRate;

            UnityEngine.Object a = Instantiate(enemy, new Vector3(UnityEngine.Random.Range(-700.0f, 700.0f), 650), Quaternion.identity);
        }
    }

    private void SpawnAsteroids()
    {
        if (Time.time > asteroidNextSpawn)
        {
            asteroidNextSpawn = Time.time + asteroidSpawnRate;

            UnityEngine.Object a = Instantiate(asteroid, new Vector3(UnityEngine.Random.Range(-700.0f, 700.0f), 650), Quaternion.identity);
        }
    }

    void OnGUI()
    {

        GUI.contentColor = Color.red;
        GUI.Label(new Rect(10, 10, 200, 22), "Lives: " + playerLives);
        GUI.Label(new Rect(10, 32, 200, 22), "Score: " + score);
    }

    void CollisionHandler(MonoBehaviour me, GameObject other, EventArgs e)
    //void CollisionHandler(MonoBehaviour me, GameObject other)
    {
        if (me.tag.Equals("Player") && other.tag.Equals("Enemy"))
        {
            playerLives--;
        }
    }
}
