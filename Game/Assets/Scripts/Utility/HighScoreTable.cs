using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using DBConnector;

public class HighScoreTable : MonoBehaviour {

    public Text header;
    public Text header2;
    public GameObject panel;
    List<HighScore> HighScores;
	// Use this for initialization
	void Start () {
        HighScores = DBController.getHighScores();
        bool first = true;
        foreach (HighScore h in HighScores)
        {
            if (first)
            {
                header.text = h.Username;
                header2.text = h.Score.ToString();
                first = false;
            } else {

                Text t = Instantiate(header, panel.transform) as Text;
                t.text = h.Username;

                t = Instantiate(header, panel.transform) as Text;
                t.text = h.Score.ToString();

            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
