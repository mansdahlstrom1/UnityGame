using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOverScript : MonoBehaviour
{
    public Text Score;
    public Text Duration;

    Player p;
    Round playedRound;


    void Start()
    {
        p = new Player();
        int latestRoundIndex = p.PlayerRounds.Count - 1;
        playedRound = p.PlayerRounds[latestRoundIndex];
        Score.text = playedRound.Score.ToString();
        Duration.text = playedRound.Duration.ToString();
    }
}
