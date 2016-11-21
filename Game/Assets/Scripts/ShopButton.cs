using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using DBConnector;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class ShopButton : MonoBehaviour, ISelectHandler {
    

    Button myButton;
    public Text Shipname;
    public Text coins;
    public string upgradeName;
    public int cost;
    public bool equipped;
    public bool owned;
    DBController dbc;

    // modal panel
    private ModalPanel modalPanel;

    void Awake()
    {
        modalPanel = ModalPanel.Instance();
        
        myButton = GetComponent<Button>();

        myButton.onClick.AddListener(Click);
    }

    // Use this for initialization
    void Start () {
        dbc = new DBController();
        this.coins.text = cost.ToString();
        this.Shipname.text = upgradeName;

    }

    private void DoNothing() { }

    private void EquipUpgrade()
    {
        Player.Active_upgrade = upgradeName;
        dbc.equipUpgrade(upgradeName);

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
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

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    void Click()
    {

        modalPanel.enabled = true;

        if (equipped)
        {
            Debug.Log("Eqippied click!");
        }
        else if(owned)
        {
            string message = "Equip " + this.upgradeName + "?";
            
            modalPanel.Choice(message, new UnityAction(EquipUpgrade), new UnityAction(DoNothing), new UnityAction(DoNothing));

        } else
        {
            string message = "Buy " + this.upgradeName + " for " + this.cost + "?";
            
            modalPanel.Choice(message, new UnityAction(TryBuyUpgrade), new UnityAction(DoNothing), new UnityAction(DoNothing));
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        //Debug.Log("Hej knapp");
    }

    // Update is called once per frame
    void Update () {
	
	}
}
