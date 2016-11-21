using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using DBConnector;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ShopButton : MonoBehaviour, ISelectHandler {

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

    // Remove this
    DBController dbc;

    // modal panel
    private ModalPanel modalPanel;

    void Start () {


    }

    public void setValues()
    {
        dbc = new DBController();
        this.coins.text = cost.ToString();
        this.Shipname.text = upgradeName;
        shop = Shop.Instance();
        modalPanel = ModalPanel.Instance();
        Button myButton = GetComponentInChildren<Button>();
        myButton.onClick.AddListener(Click);
        avatar.sprite = Resources.Load<Sprite>("Images/Ships/" + upgradeName);

    }

    void Click()
    {
        shop.Click(upgradeName, cost, state);
    }

    public void OnSelect(BaseEventData eventData)
    {
        //Debug.Log("Hej knapp");
    }

    // Update is called once per frame
    void Update () {
	
	}
}
