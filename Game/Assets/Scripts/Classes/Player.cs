using System;
using System.Collections.Generic;
using System.Security.Cryptography;

public static class Player
{
    static string username;
    static string hash;
    static DateTime activity;
    static DateTime created;
    static int coins;
    static string active_upgrade;
    static Round latestRound;
    static int highScore;
    static List<Upgrade> playerUpgrades;
    static Dictionary<int, Multiplayer> multiPlayers = new Dictionary<int, Multiplayer>();

    public static string Username { get { return username; } set { username = value; } }
    public static DateTime Activty { get { return activity; } set { activity = value; } }
    public static int Coins { get { return coins; } set { coins = value; } }
    public static DateTime Created { get { return created; } set { created = value; } }
    public static string Active_upgrade { get { return active_upgrade;  } set { active_upgrade = value; } }
    public static string Hash { get { return hash; } set { hash = value; } }
    public static List<Upgrade> PlayerUpgrades { get { return playerUpgrades; } set { playerUpgrades = value; } }
    public static Dictionary<int, Multiplayer> MultiPlayers { get { return multiPlayers; } set { multiPlayers = value; } }
    public static Round LatestRound { get { return latestRound; } set { latestRound = value; } }
    public static int HighScore { get { return highScore; } set { highScore = value; } }

    public static bool checkPassword(string password)
    {
        // Input password
        Byte[] data = System.Text.Encoding.UTF8.GetBytes(password);
        Byte[] hash = new SHA256CryptoServiceProvider().ComputeHash(data);
        string hashedPassword = Convert.ToBase64String(hash);

        // Password from DB
        string fixedHash = Hash.Replace(" ", "+").Replace("-", "/");

        if (fixedHash == hashedPassword)
        {
            return true;
        } else
        {
            return false;
        }
    }

    public static void createTestUser()
    {
        username = "DebugUser";
        coins = 10000000;
        active_upgrade = "Dogpool";
    }


}
