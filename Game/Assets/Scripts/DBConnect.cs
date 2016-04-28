using UnityEngine;
using System;
using MySql.Data.MySqlClient;

public class DBConnect : MonoBehaviour
{

    MySqlConnection conn;
    string myConnectionString = null;
    MySqlDataReader dataReader;

    public DBConnect()
    {

        myConnectionString = "server=89.236.61.189;database=nyancat;uid=remote_user;pwd=PASSWORD;";

        try
        {
            conn = new MySqlConnection();
            conn.ConnectionString = myConnectionString;

        }
        catch (MySqlException ex)
        {
            Debug.Log(ex);
        }
    }

    public Player getPlayerByUsername(String username)
    {
        conn.Open();
        MySqlCommand cmd;
        MySqlDataReader rdr;
        string sql = "select * from user where username = @username";
        Player p1 = new Player();


        cmd = new MySqlCommand();
        cmd.Connection = conn;
        cmd.CommandText = sql;
        cmd.Prepare();
        cmd.Parameters.AddWithValue("@username", username);



        rdr = cmd.ExecuteReader();

        while (rdr.Read())
        {
            p1.Username = rdr.GetString("username");
            p1.Hash = rdr.GetString("hash");
            p1.Activty = (DateTime)rdr.GetMySqlDateTime("activity");
            p1.Coins = rdr.GetInt32("coins");
            p1.Created = (DateTime)rdr.GetMySqlDateTime("created");
            p1.IsAdmin = rdr.GetBoolean("isAdmin");

        }
        conn.Close();

        return p1;

    }

}
