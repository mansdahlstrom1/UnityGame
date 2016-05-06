using UnityEngine;
using System.Collections;

public class GUIMainMenu : MonoBehaviour {

    string stringToEdit;
    public Texture coins;
    Player p;


    // Use this for initialization
    void Start () {
        p = new Player();
        Debug.Log("We are starting");
       
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        if (p.Username == null)
        {
            stringToEdit = "You are not logged in";
        } else
        {
            GUI.DrawTexture(new Rect(10, 480, 20, 20), coins);
            GUI.Label(new Rect(10, 450, 200, 30), "<size=20><b>" +  p.Username.ToUpper() + "</b></size>");
            GUI.Label(new Rect(30, 480, 200, 30), "<size=16><b>" + p.Coins.ToString() + "</b></size>");
            GUI.Label(new Rect(10, 500, 200, 30), "<size=16><b>High Score: <color=#e5c100>" + p.getBestScore().ToString() + "</color></b></size>");
        }
        
       
    }

}
