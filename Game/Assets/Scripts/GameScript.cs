using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using System;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{

    //Game Logic
    public int playerLives = 3;
    public int score = 0;
    public bool isPause = false;
    public float roundStart;
    //GUI
    GUIStyle labelStyle = new GUIStyle();

    //Player
    public List<PlayerShip> players;

    //Boss
    public GameObject boss;
    public float bossSpawnRate;
    private float bossNextSpawn = 15;


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
        roundStart = Time.time;

        labelStyle.border = new RectOffset(10, 10, 10, 10);

        //Add collision listener to all ships
        foreach (PlayerShip ship in players)
        {
            Instantiate(ship, new Vector3(0, -900), Quaternion.identity);
            //ship.collisionEvent += new PlayerShip.CollisionEvent(CollisionHandler);
        }

        labelStyle.fontSize = 22;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
        }
        if (isPause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    void FixedUpdate()
    {
        //SpawnEnemies();
        SpawnAsteroids();
        SpawnBoss();

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

    private void SpawnBoss()
    {
        if (Time.time > bossNextSpawn)
        {
            bossNextSpawn = Time.time + bossSpawnRate;
            UnityEngine.Object a = Instantiate(boss, new Vector3(UnityEngine.Random.Range(-700.0f, 700.0f), 650), Quaternion.identity);
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

    void PauseGame(int windowID)
    {
        if (GUI.Button(new Rect(65, 30, 120, 40), "Contiune"))
            isPause = false;
        if (GUI.Button(new Rect(65, 70, 120, 40), "This is to hard..."))
            SceneManager.LoadScene("GameOver");

    }

    Rect CenterRectangle(Rect rect)
    {
        rect.x = (Screen.width - rect.width) / 2;
        rect.y = (Screen.height - rect.height) / 2;
        return rect;
    }



    void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.fontSize = 18;
        style.normal.textColor = Color.white;

        GUI.Label(new Rect(10, 10, 200, 22), "Lives: " + playerLives, style);
        GUI.Label(new Rect(10, 32, 200, 22), "Score: " + score, style);

        if (isPause)
        {
            GUI.Window(0, CenterRectangle(new Rect(100, 100, 250, 120)), PauseGame, "Pause Menu");

        }
    }

    void CollisionHandler(MonoBehaviour me, GameObject other)
    {
        if (me.tag.Equals("Player") && other.tag.Equals("Enemy"))
        {
            if (playerLives > 0)
            {
                if (!me.GetComponent<PlayerShip>().IsInvulnerable)
                    playerLives--;
            }
            else
            {
                try
                {
                    Round r = new Round();
                    r.Score = score;
                    r.Duration = (int)Time.time - (int)roundStart;
                    r.Coins = 500;
                    Player.PlayerRounds.Add(r);

                    Utils.ChangeScene("GameOver");

                }
                catch (Exception e)
                {
                    Debug.Log("Failed to create round; msg = " + e);   
                }
               
            }
        }
    }
}
