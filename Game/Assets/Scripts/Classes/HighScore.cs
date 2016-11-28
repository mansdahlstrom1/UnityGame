
using System;

public class HighScore {

    private string username;
    private int score;

    public string Username { get { return username; } set { username = value; } }
    public int Score { get { return score; } set { score = value; } }
}

[Serializable]
public class HighScoreData
{
    public string username;
    public int score;

    public HighScore getHighScore()
    {
        HighScore h = new HighScore();
        h.Username = username;
        h.Score = score;
        return h;
    }
}
