using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInterface : MonoBehaviour {

    public Texture coins;
    public string leftText;
    public string centerText;
    public string rightText;

    GameObject canvas;
    GameObject playerInterface;
    private Text[] texts;
    int sw = Screen.height;
    int sh = Screen.width;
    Vector3 lowLeft = Camera.current.WorldToScreenPoint(new Vector3(0,0,0));


    //DBConnector.DBController db = new DBConnector.DBController();



    // Use this for initialization

    void Start () {

        Debug.Log(lowLeft.x + " - " + lowLeft.y);
        Debug.Log(" screen height = " + sh + "screen Width = " + sw);

        //db.GetCompletePlayer(Player.Username);
        playerInterface = Resources.Load<GameObject>("Prefabs/Player/misc/PlayerInterface");
        PlayerShip ps = playerInterface.GetComponentInChildren<PlayerShip>();
        float width = playerInterface.GetComponent<RectTransform>().rect.width;
        float height = playerInterface.GetComponent<RectTransform>().rect.height;
        Vector3 psTransform = new Vector3((width / 2) + 20f, (height / 2) + 20f);
        Debug.Log("Width: " + width + "; Height: " + height);

        ps.ShopMode = true;
        ps.Disabled = true;
        Text[] texts = playerInterface.GetComponentsInChildren<Text>();
        if (Player.Username != null)
        {   
            texts[0].text = Player.Username.ToUpper();
            texts[2].text = Player.Coins.ToString();
            texts[1].text = "<b>High Score: <color=#e5c100>" + Player.GetBestScore().ToString() + "</color></b>";
            Instantiate(playerInterface, psTransform, Quaternion.identity, gameObject.transform);
        }
        else
        {
            
            texts[0].text = leftText;
            texts[2].text = rightText;
            texts[1].text = "<b>High Score: <color=#e5c100>" + Player.GetBestScore().ToString() + "</color></b>";

            Instantiate(playerInterface, new Vector3(-100,-100), Quaternion.identity, gameObject.transform);

        }

    }

    // Update is called once per frame
    void Update () {
	
	}

}
