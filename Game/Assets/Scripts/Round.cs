using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Round
{
    private int roundid;
    private int coins;
    private DateTime created;
    private int duration;
    private int score;

    public int Roundid { get { return roundid; } set { roundid = value; } }
    public int Coins { get { return coins; } set { coins = value; } }
    public DateTime Created { get { return created; } set { created = value; } }
    public int Duration { get { return duration; } set { duration = value; } }
    public int Score { get { return score; } set { score = value; } }
}
