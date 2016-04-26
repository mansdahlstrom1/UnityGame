using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Login : MonoBehaviour {

    private string username;
    private string password;

    public string Username { set { username = value; } get { return username;}}
    public string Password { set { password = value; } get { return password;}}



    DBConnect con = new DBConnect();
    public void loginUser()
    {
        if (Username.Length != 0 && Password.Length != 0)
        {
            Player p1 = con.getPlayerByUsername(Username);

            //Debug.Log(p1.Username);
            if (p1.CheckLogin(Password))
            {
                Debug.Log("Logged in!");
            }
            else
            {
                Debug.Log("not Logged in");
            }

            //Temp
            MenuScript.ChangeScene("MainMenu");
        }
    }


   

}
