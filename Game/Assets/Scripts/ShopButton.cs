using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEditor;
using DBConnector;
using UnityEngine.SceneManagement;

public class ShopButton : MonoBehaviour, ISelectHandler {
    

    Button myButton;
    public Text Shipname;
    public Text coins;
    public string upgradeName;
    public int cost;
    public bool equipped;
    public bool owned;
    DBController dbc;
   
    // Use this for initialization
    void Start () {
        dbc = new DBController();
        this.coins.text = cost.ToString();
        this.Shipname.text = upgradeName;

    }

    void Awake()
    {
        myButton = GetComponent<Button>();

        myButton.onClick.AddListener(Click);
    }

    void Click()
    {
        if (equipped)
        {
            Debug.Log("Eqippied click!");
        }
        else if(owned)
        {
            string message = "Equip " + this.upgradeName + "?";
            bool choice = EditorUtility.DisplayDialog("Confirm dialog", message, "Equip", "Cancel");

            if (choice)
            {
                Player.Active_upgrade = upgradeName;
                dbc.equipUpgrade(upgradeName);
                Scene scene = SceneManager.GetActiveScene();
                SceneManager.LoadScene(scene.name);
            }

        } else
        {
            string message = "Buy " + this.upgradeName + " for " + this.cost + "?";
            bool choice = EditorUtility.DisplayDialog("Confirm dialog", message, "Buy", "cancel");

            if (choice)
            {
                if (Player.Coins >= cost)
                {
                    dbc.buyUpgrade(upgradeName);
                    Player.Coins -= cost;
                    Scene scene = SceneManager.GetActiveScene();
                    SceneManager.LoadScene(scene.name);

                }
                else
                {
                    EditorUtility.DisplayDialog("Not enough coins", "You are missing " + (cost - Player.Coins) + ". Play some more games and come back!", "ok");
                }
            }
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
