using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;

public static class Player
{

    static string username;
    static DateTime activity;
    static bool isAdmin;
    static int coins;
    static DateTime created;
    static string hash;
    static Options options;
    static List<Round> playerRounds;
    static List<Upgrade> playerUpgrades;

    public static string Username { get { return username; } set { username = value; } }
    public static DateTime Activty { get { return activity; } set { activity = value; } }
    public static bool IsAdmin { get { return isAdmin; } set { isAdmin = value; } }
    public static int Coins { get { return coins; } set { coins = value; } }
    public static DateTime Created { get { return created; } set { created = value; } }
    public static string Hash { get { return hash; } set { hash = value; } }
    public static Options Options { get { return options; } set { options = value; } }
    public static List<Round> PlayerRounds { get { return playerRounds; } set { playerRounds = value; } }
    public static List<Upgrade> PlayerUpgrades { get { return playerUpgrades; } set { playerUpgrades = value; } }


    public static int GetBestScore()
    {
        int bestScore = 0;
        if(playerRounds != null)
        {
            for (var i = 0; i < playerRounds.Count; i++)
            {
                if (playerRounds[i].Score > bestScore)
                {
                    bestScore = playerRounds[i].Score;
                }
            }
        }
        return bestScore;
    }

    public static bool checkPassword(string password)
    {
        // Input password
        Byte[] data = System.Text.Encoding.UTF8.GetBytes(password);
        Byte[] hash = new SHA256CryptoServiceProvider().ComputeHash(data);
        string hashedPassword = Convert.ToBase64String(hash).Replace("-", "/");

        // Password for DB
        string fixedHash = Hash.Replace(" ", "+");
        Debug.Log("p.hash = " + fixedHash);
        Debug.Log("entered = " + hashedPassword);

        if (fixedHash == hashedPassword)
        {
            Debug.Log("True");
            return true;
        } else
        {
            Debug.Log("False");
            return false;
        }
    }
}
