using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Net;
using DBConnector;
using System.Collections.Generic;

public class Login : MonoBehaviour
{

    private string username;
    private string password;

    public string Username { set { username = value; } get { return username; } }
    public string Password { set { password = value; } get { return password; } }

    public void loginUser()
    {
        if (Username.Length != 0 && Password.Length != 0)
        {
            DBController controller = new DBController();
            Player p = controller.GetCompletePlayer(username);


            if (p == null)
            {
                Debug.Log("Invalid Username, couldn't find a User with that username");
            } else
            {
                if (p.CheckLogin(Password))
                {
                   Debug.Log("Logged in!");

                }
                else
                {
                    Debug.Log("Password incorrect, try again");
                }
            }
            Utils.ChangeScene("MainMenu");
        }
    }


}
