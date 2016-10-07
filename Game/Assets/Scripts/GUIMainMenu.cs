using UnityEngine;
using System.Collections;

public class GUIMainMenu : MonoBehaviour {

    string stringToEdit;
    public Texture coins;
    public int sh = Screen.height;
    public int sw = Screen.width;


    // Use this for initialization
    void Start () {
        Debug.Log("We are starting");       
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (Player.Username == null)
        {
            stringToEdit = "You are not logged in";
        } else
        {
            GUI.Label(new Rect(40, sh - 100, 200, 30), "<size=20><b>" + Player.Username.ToUpper() + "</b></size>");
            GUI.DrawTexture(new Rect(40, sh - 70, 20, 20), coins);
            GUI.Label(new Rect(60, sh - 70, 200, 30), "<size=16><b>" + Player.Coins.ToString() + "</b></size>");
            GUI.Label(new Rect(40, sh - 50, 200, 30), "<size=16><b>High Score: <color=#e5c100>" + Player.GetBestScore().ToString() + "</color></b></size>");
        }
        
       
    }

}
