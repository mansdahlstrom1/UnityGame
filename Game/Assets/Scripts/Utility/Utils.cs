using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Utils : MonoBehaviour
{


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

    public static Dictionary<string, Sprite> getPlayerSprites()
    {
        Dictionary<string, Sprite> list = new Dictionary<string, Sprite>();
        foreach (Upgrade u in Player.PlayerUpgrades)
        {
            Sprite s = Resources.Load<Sprite>("Images/Ships/" + u.UpgradeName);
            list.Add(u.UpgradeName, s);
        }
        return list;
    }
    public static float GetPercentOfScreenH(int percent)
    {
        int OnePercent = Camera.main.pixelHeight / 100;
        Debug.Log(OnePercent);
        Debug.Log(percent + " (height) = " + OnePercent * percent);

        return OnePercent * percent;
    }
    public static float GetPercentOfScreenW(int percent)
    {
        int OnePercent = Camera.main.pixelWidth / 100;
        Debug.Log(percent + " (width) = " + OnePercent * percent);
        return OnePercent * percent;
    }

    public static string convertByte(int bytes)
    {
        double kb = bytes / 1024f;
        double mb = kb / 1024f;

        if (mb < 1)
            return Math.Round(kb, 3) + "kB";
        else
            return Math.Round(mb, 3) + "MB";
    }
}
