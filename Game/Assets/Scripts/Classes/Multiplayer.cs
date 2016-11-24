using UnityEngine;
using System.Collections.Generic;

public class Multiplayer {

    public int PlayerNumber;
    public string Active_upgrade;

    public Multiplayer(int playerNumber, string active_upgrade)
    {
        PlayerNumber = playerNumber;
        Active_upgrade = active_upgrade;
    }
}
