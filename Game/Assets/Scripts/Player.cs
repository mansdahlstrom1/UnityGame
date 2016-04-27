using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour {

    static string username;
    static DateTime activity;
    static bool isAdmin;
    static int coins;
    static DateTime created;
    static string hash;

    public string Username { get { return username; } set { username = value; } }
    public DateTime Activty { get { return activity; } set { activity = value; } }
    public bool IsAdmin { get { return isAdmin; } set { isAdmin = value; } }
    public int Coins { get { return coins; } set { coins = value; } }
    public DateTime Created { get { return created; } set { created = value; } }
    public string Hash { get { return hash; } set { hash = value; } }

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
