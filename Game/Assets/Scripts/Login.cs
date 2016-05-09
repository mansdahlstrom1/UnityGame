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
    public Text ErrorMessage;

    public string Username { set { username = value; } get { return username; } }
    public string Password { set { password = value; } get { return password; } }

    public void LoginUser()
    {
        if (Username != null && Password != null)
        {
            if (Username.Length > 0 && Password.Length > 0)
            {
                DBController controller = new DBController();
                Player p = controller.GetCompletePlayer(username);

                Debug.Log(p.Username.Length);
                if (p == null || p.Username.Length == 0)
                {
                    ErrorMessage.text = "Invalid Username \n Please try again";
                }
                else
                {
                    Utils.ChangeScene("MainMenu");
                }

            }
            else
            {
                ErrorMessage.text = "Please enter both Username and Password";
            }
        }
        else
        {
            ErrorMessage.text = "Please enter both Username and Password";
        }
    }


}
