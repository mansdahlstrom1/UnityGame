using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Utils : MonoBehaviour {


    public enum UpgradeStates { NotOwned = 0, Owned = 1, Equipped = 2 }

    void Start()
    {

    }
    void Update()
    {

    }

    public void ChangeSceneClick(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void ExitAppliction()
    {
        Application.Quit();
    }

    public static void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
