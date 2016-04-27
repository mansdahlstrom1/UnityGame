using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using System.Text;
using System.Security.Cryptography;

public class Utils : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
