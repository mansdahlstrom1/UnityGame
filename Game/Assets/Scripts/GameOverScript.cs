using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using DBConnector;

public class GameOverScript : MonoBehaviour
{
    public Text Score;
    public Text Duration;
    public Text Coins;

    Round playedRound;

    DBController conn = new DBController();

    void Start()
    {
        
        int latestRoundIndex = Player.PlayerRounds.Count - 1;
        playedRound = Player.PlayerRounds[latestRoundIndex];
        Score.text = playedRound.Score.ToString();
        Duration.text = playedRound.Duration.ToString();
        Coins.text = playedRound.Coins.ToString();
        conn.CreateRound(playedRound, Player.Username);

    }
}
