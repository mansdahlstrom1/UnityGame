using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class Player {

    static string username;
    static DateTime activity;
    static bool isAdmin;
    static int coins;
    static DateTime created;
    static string hash;
    private Options options;
    private List<Round> playerRounds;
    private List<Upgrade> playerUpgrades;

    public string Username { get { return username; } set { username = value; } }
    public DateTime Activty { get { return activity; } set { activity = value; } }
    public bool IsAdmin { get { return isAdmin; } set { isAdmin = value; } }
    public int Coins { get { return coins; } set { coins = value; } }
    public DateTime Created { get { return created; } set { created = value; } }
    public string Hash { get { return hash; } set { hash = value; } }
    public Options Options { get { return options; } set { options = value; } }
    public List<Round> PlayerRounds { get { return playerRounds; } set { playerRounds = value; } }
    public List<Upgrade> PlayerUpgrades { get { return playerUpgrades; } set { playerUpgrades = value; } }

    public bool CheckLogin(string password)
    {

        string HashedPassword = Password.Decrypt(password);
        Debug.Log("from Utils = " + HashedPassword);
        Debug.Log("from Player = " + Hash);
        if (Hash.Equals(HashedPassword))
            return true;
        else 
            return false;
    }

}
