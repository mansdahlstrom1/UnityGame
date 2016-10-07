using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{    
    void Start()
    {
    }

    void Update()
    {

    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void ExitAppliction()
    {
        Application.Quit();
    }

    public void Options()
    {
        Canvas canvas = this.GetComponent<Canvas>();
    }

}
