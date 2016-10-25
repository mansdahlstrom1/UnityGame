using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopButton : MonoBehaviour, ISelectHandler {

    Button myButton;
    public Text Shipname;
    public Text coins;
    public string upgradeName;
    public int cost;

    // Use this for initialization
    void Start () {

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
        Debug.Log("klick knapp" + this.upgradeName + " " + this.cost);
        
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("Hej knapp");
    }

    // Update is called once per frame
    void Update () {
	
	}
}
