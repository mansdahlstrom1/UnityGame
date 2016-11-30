using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections.Generic;

public class GameScript : MonoBehaviour
{
    //Game Logic
    public int playerLives = 3;
    public int score = 0;
    public bool isPause = false;
    public float roundStart;

    public static int coinsEarned = 0;

    //GUI
    GUIStyle labelStyle = new GUIStyle();
    // modal panel
    private ModalPanel modalPanel;
    
    //Player
    //public List<PlayerShip> players = new List<PlayerShip>();

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

    int startPos = 0;

    // Use this for initialization
    void Start()
    {

        if (Player.MultiPlayers.Count > 0)
        {
            startPos = -100 * Player.MultiPlayers.Count;
        }
        
        PlayerShip ps = Resources.Load<PlayerShip>("prefabs/Player/ships/" + Player.Active_upgrade);
        
        PlayerShip ps2 = Instantiate(ps, new Vector3(startPos, -900), Quaternion.identity) as PlayerShip;
        ps2.PlayerNumber = 1;

        startPos += 200;

        foreach (Multiplayer mp in Player.MultiPlayers.Values)
        {
            PlayerShip mps = Resources.Load<PlayerShip>("prefabs/Player/ships/" + mp.Active_upgrade);
            
            PlayerShip mps2 = Instantiate(mps, new Vector3(startPos, -900), Quaternion.identity) as PlayerShip;
            Debug.Log(mp.Active_upgrade + " Has number : " + mp.PlayerNumber);
            mps2.PlayerNumber = mp.PlayerNumber;

            startPos += 200;
        }
        
        coinsEarned = 0;
        PlayerShip.lives = playerLives;
        roundStart = Time.time;
        modalPanel = ModalPanel.Instance();

        labelStyle.border = new RectOffset(10, 10, 10, 10);

        
        UnPause();
        labelStyle.fontSize = 22;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Start"))
        {
            if (modalPanel.enabled)
            {
                PauseGame();
            }
            else
            {
                UnPause();
            }
        }
    }

    void FixedUpdate()
    {
        if (PlayerShip.lives < 1)
            GameOver();

        SpawnEnemies();
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

    void PauseGame()
    {

        Time.timeScale = 0;
        modalPanel.enabled = true;

        modalPanel.Choice("Do you want to exit current game?", new UnityAction(GameOver), new UnityAction(UnPause), new UnityAction(UnPause));

    }

    void UnPause()
    {
        Time.timeScale = 1;
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

        GUI.Label(new Rect(10, 10, 200, 22), "Lives: " + PlayerShip.lives, style);
        GUI.Label(new Rect(10, 32, 200, 22), "Score: " + score, style);
        GUI.Label(new Rect(10, 54, 200, 22), "Coins: " + coinsEarned, style);

    }

    void GameOver()
    {
        try
        {
            Round r = new Round();
            r.Score = score;
            r.Duration = (int)Time.time - (int)roundStart;
            r.Coins = coinsEarned;
            Player.LatestRound = r;

            Utils.ChangeScene("GameOver");

        }
        catch (Exception e)
        {
            Debug.Log("Failed to create round; msg = " + e);
        }
    }
}
