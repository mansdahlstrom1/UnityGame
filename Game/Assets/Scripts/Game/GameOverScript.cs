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


    void Start()
    {
        playedRound = Player.LatestRound;
        Score.text = playedRound.Score.ToString();
        Duration.text = playedRound.Duration.ToString();
        Coins.text = playedRound.Coins.ToString();
        DBController.CreateRound(playedRound, Player.Username);
        DBController.GetCompletePlayer(Player.Username);
    }
}
