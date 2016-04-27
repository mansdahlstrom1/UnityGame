using UnityEngine;
using System.Collections;

public class GUIMainMenu : MonoBehaviour {

    string stringToEdit;
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
            stringToEdit = "Welcome " + p.Username;
        }
        
        GUI.Label(new Rect(10, 10, 200, 20), stringToEdit);
    }

}
