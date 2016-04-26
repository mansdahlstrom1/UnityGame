using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    Text iField;
    Player p = new Player();


    public MenuScript()
    {
        iField = GetComponent<Text>();
        setPlayerTexts();
        Debug.Log("We are starting");
    }

    void start()
    {
        setPlayerTexts();
        Debug.Log("We are starting");
    }

    void update()
    {

    }

    public static void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void exitAppliction()
    {
        Application.Quit();
    }

    public void Options()
    {
        Canvas canvas = this.GetComponent<Canvas>();
    }

    public void setPlayerTexts()
    {
        Debug.Log("Name = " + iField.text.ToString());
        iField.text = p.Username;
    }

    
}
