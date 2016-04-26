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
        Debug.Log("check input: " + password);
        Debug.Log("check object.hash: " + Hash);

        string decryptedHash = getDeryptedHash();

        if (password.Equals(decryptedHash))
            return true;
        else 
            return false;
    }

    public string getDeryptedHash()
    {
        string password;

        //password = Sha164 (or something..) this.hash;
        password = Hash;

        return password;
    }
}
