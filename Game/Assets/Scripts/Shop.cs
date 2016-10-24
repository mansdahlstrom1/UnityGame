using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public GameObject canvas;
    public Button btn;
    List<GameObject> ships = new List<GameObject>();
    
    // Use this for initialization
    void Start()
    {
        //canvas = gameObject.GetComponent<Canvas>();
        // Load all ships and show as a table
        string[] fromDB = { "Digger Yellow", "Digger Green", "Dogpool", "Castle Red", "Castle Grey", "V-Wing White", "V-Wing Pink", "Enemy" };
        string path = "Prefabs/Player/Ships/";
        int i = 0, my_x = -300, my_y = 100;

        foreach (string file in fromDB)
        {
            if (i % 3 == 0 && i != 0)
            { 
                my_x = -300;
                my_y -= 200;
            }
            Button button = Instantiate(btn, new Vector3(my_x, my_y), Quaternion.identity, canvas.transform) as Button;
            GameObject ship = Instantiate(Resources.Load(path + file), new Vector3(my_x, my_y + 15), Quaternion.identity, canvas.transform) as GameObject;
            PlayerShip shipFoRealz = ship.GetComponent<PlayerShip>();
            shipFoRealz.ShopMode = true;
            shipFoRealz.Disabled = true;
            Text btnText = button.GetComponentInChildren<Text>();
            btnText.text = file + "\n";
            //shipText.alignment = TextAnchor.MiddleCenter;
            //shipText.color = Color.white;
            //shipText.fontSize = 52;
            //Font arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");
            //shipText.font = arial;
            //shipText.material = arial.material;

            ships.Add(ship);
            my_x += 300;
            i++;
        }
    }

    void OnGUI()
    {
       //GUI.Label(new Rect(my_x, my_y, 100, 20), "Test");
    }

    // Update is called once per frame
    void Update()
    {
        // get selected item.
        // set this playership from list top active for shooting
    }
}