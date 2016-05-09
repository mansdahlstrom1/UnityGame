using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DBConnector;

public class GameOverScript : MonoBehaviour
{
    public Text Score;
    public Text Duration;
    public Text Coins;

    Player p;
    Round playedRound;

    DBController conn = new DBController();

    void Start()
    {
        p = new Player();
        int latestRoundIndex = p.PlayerRounds.Count - 1;
        playedRound = p.PlayerRounds[latestRoundIndex];
        Score.text = playedRound.Score.ToString();
        Duration.text = playedRound.Duration.ToString();
        Coins.text = playedRound.Coins.ToString();
        conn.CreateRound(playedRound, p.Username);

    }
}
