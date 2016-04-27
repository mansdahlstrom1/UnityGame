using UnityEngine;
using System.Collections;

public class Password : MonoBehaviour {

    private static string alogrythm = "AES";
    private static string key = "1Hbfh667adfDEJ78";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static string Encrypt(string pwd)
    {
        return pwd;
    }

    public static string Decrypt(string pwd)
    {
        return pwd;
    }


}
