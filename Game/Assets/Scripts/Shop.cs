﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DBConnector;

public class Shop : MonoBehaviour
{
    public GameObject canvas;
    public Button btn;
    List<GameObject> ships = new List<GameObject>();

    private DBController dbc = new DBController();

    // Use this for initialization
    void Start()
    {
        List<Upgrade> upgrades = dbc.GetAllUpgrades();
        string path = "Prefabs/Player/Ships/";
        int i = 0, my_x = -300, my_y = 100;

        foreach (Upgrade upgrade in upgrades)
        {
            if (i % 3 == 0 && i != 0)
            { 
                my_x = -300;
                my_y -= 200;
            }

            Button button = Instantiate(btn, new Vector3(my_x, my_y), Quaternion.identity, canvas.transform) as Button;
            GameObject ship = Instantiate(Resources.Load(path + upgrade.UpgradeName), new Vector3(my_x, my_y + 15), Quaternion.identity, canvas.transform) as GameObject;
            PlayerShip shipFoRealz = ship.GetComponent<PlayerShip>();
            shipFoRealz.ShopMode = true;
            shipFoRealz.Disabled = true;
            ShopButton shopBtn = button.GetComponent<ShopButton>();
            shopBtn.upgradeName = upgrade.UpgradeName;
            shopBtn.cost = upgrade.Cost;

            //button.onClick()

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