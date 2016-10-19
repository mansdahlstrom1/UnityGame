using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

        // Load all ships and show as a table
        string[] fromDB = { "Digger Yellow.prefab" };
        string path = "/Assets/Prefabs/Player/Ships/";

        foreach (string file in fromDB)
        {
            Debug.Log(path+file);
            //GameObject myItem = Instantiate(Resources.Load(path+file)) as GameObject;
            GameObject myItem = Instantiate(Resources.Load("Dogpool")) as GameObject;
            string ship = file.Substring(path.Length);
            Debug.Log(ship);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
