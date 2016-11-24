using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DBConnector;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour
{
    public GameObject canvas;
    List<GameObject> ships = new List<GameObject>();
    EventSystem ev;
    private DBController dbc = new DBController();
    private static ModalPanel modalPanel;
    // Use this for initialization

    // clickParameters
    private string upgradeName;
    private int cost;
    private int state;

    private static Shop shop;

    public static Shop Instance()
    {
        if (!shop)
        {
            shop = FindObjectOfType(typeof(Shop)) as Shop;
            if (!shop)
                Debug.LogError("There needs to be one active ModalPanel script on a GameObject in your scene.");
        }

        return shop;
    }

    void Start()
    {
        modalPanel = ModalPanel.Instance();
        List<Upgrade> upgrades = dbc.GetAllUpgrades();
        ev = EventSystem.current;

        int i = 0, my_x = -300, my_y = 50;
        foreach (Upgrade upgrade in upgrades)
        {

            int state = 0;
            if (i % 3 == 0 && i != 0)
            { 
                my_x = -300;
                my_y -= 110;
            }

            foreach (Upgrade u in Player.PlayerUpgrades)
            {
                if (upgrade.UpgradeName.Equals(u.UpgradeName))
                {
                    state = u.UpgradeName == Player.Active_upgrade 
                        ? (int)Utils.UpgradeStates.Equipped 
                        : (int)Utils.UpgradeStates.Owned;
                } 
            }


            // Load UpgradePane
            GameObject upgradePane = Resources.Load<GameObject>("Prefabs/Misc/UpgradePane");

            GameObject up = Instantiate(upgradePane, new Vector3(my_x, my_y), Quaternion.identity, canvas.transform) as GameObject;

            ShopButton shopBtn = up.GetComponent<ShopButton>();
            shopBtn.upgradeName = upgrade.UpgradeName;
            shopBtn.cost = upgrade.Cost;
            shopBtn.state = state;
            shopBtn.setValues();
            my_x += 300;
            i++;
        }
    }

    private void DoNothing() {
        EventSystem.current.SetSelectedGameObject(ev.firstSelectedGameObject);
    }
    private void EquipUpgrade()
    {
        Player.Active_upgrade = upgradeName;
        dbc.equipUpgrade(upgradeName);

        Utils.ReloadScene();
    }

    private void TryBuyUpgrade()
    {
        if (Player.Coins >= cost)
        {
            dbc.buyUpgrade(upgradeName);
            Player.Coins -= cost;
        }
        else
        {
            string message = "Not enough coins\nYou are missing " + (cost - Player.Coins) + ". Play some more games and come back!";

            modalPanel.Choice(message, new UnityAction(EquipUpgrade), new UnityAction(DoNothing), new UnityAction(DoNothing));
        }

        Utils.ReloadScene();
    }

    public void Click(string upgradeName, int cost, int state)
    {

        modalPanel.enabled = true;
        setValues(upgradeName, cost, state);

        if (state == (int)Utils.UpgradeStates.Equipped)
        {
            Debug.Log("Eqippied click!");
        }
        else if (state == (int)Utils.UpgradeStates.Owned)
        {
            string message = "Equip " + upgradeName + "?";

            modalPanel.Choice(message, new UnityAction(EquipUpgrade), new UnityAction(DoNothing), new UnityAction(DoNothing));

        }
        else
        {
            string message = "Buy " + upgradeName + " for " + cost + "?";

            modalPanel.Choice(message, new UnityAction(TryBuyUpgrade), new UnityAction(DoNothing), new UnityAction(DoNothing));
        }
    }

    private void setValues(string upgradeName, int cost, int state)
    {
        this.upgradeName = upgradeName;
        this.cost = cost;
        this.state = state;
    }

    // Update is called once per frame
    void Update()
    {
        // get selected item.
        // set this playership from list top active for shooting
    }
}