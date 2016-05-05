using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Net;

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
            //User
            string url = "http://81.186.252.203/webservice/VetrarbrautinWebService.php?op=findUserByUsername&username=" + username;
            var json = new WebClient().DownloadString(url);
            Debug.Log(json);
            Player p = JsonUtility.FromJson<Player>(json);

            // OPtions
            string url2 = "http://81.186.252.203/webservice/VetrarbrautinWebService.php?op=findUserOptions&username=" + username;
            var json2 = new WebClient().DownloadString(url2);
            Debug.Log(json2);
            Options o = JsonUtility.FromJson<Options>(json2);
            Debug.Log(o.Master_sound);
            if (p == null)
            {
                Debug.Log("player is null");
            } else
            {
                Debug.Log(p.Username);
            }
            /*
            if (p1.CheckLogin(Password))
            {
                Debug.Log("Logged in!");

            }
            else
            {
                Debug.Log("Password or Username was incorrect");

            }

            Utils.ChangeScene("MainMenu");
            */



        }
    }


}
