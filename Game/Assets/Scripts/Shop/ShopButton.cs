using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using DBConnector;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ShopButton : MonoBehaviour {

    public Button myButton;
    Shop shop;

    //Display
    public Text Shipname;
    public Text coins;
    public Image avatar;
    // Data
    public string upgradeName;
    public int cost;
    public int state;

    void Start () {

    }

    public void setValues()
    {
        this.coins.text = cost.ToString();
        this.Shipname.text = upgradeName;
        shop = Shop.Instance();
        myButton = GetComponentInChildren<Button>();
        myButton.onClick.AddListener(Click);
        if (this.state != (int)Utils.UpgradeStates.NotOwned)
        {
            ColorBlock colorBlock = myButton.colors;
            colorBlock.normalColor = Colors.vPurple;
            myButton.colors = colorBlock;
        }
        avatar.sprite = Resources.Load<Sprite>("Images/Ships/" + upgradeName);
    }

    void Click()
    {
        shop.Click(upgradeName, cost, state);
    }

    // Update is called once per frame
    void Update () {
	
	}
}
