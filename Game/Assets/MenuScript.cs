﻿using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

    public void ChangeScene(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }

    public void exitAppliction()
    {
        Application.Quit();
    }

    public void Options()
    {
        Canvas canvas = this.GetComponent<Canvas>();
    }
}