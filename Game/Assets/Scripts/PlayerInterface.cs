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

    DBConnector.DBController db = new DBConnector.DBController();



    // Use this for initialization

    void Start () {

        db.GetCompletePlayer(Player.Username);
        playerInterface = Resources.Load<GameObject>("Prefabs/Player/misc/PlayerInterface");
        PlayerShip ps = playerInterface.GetComponentInChildren<PlayerShip>();
        ps.ShopMode = true;
        ps.Disabled = true;
        Text[] texts = playerInterface.GetComponentsInChildren<Text>();
        if (Player.Username != null)
        {
            
            texts[0].text = Player.Username.ToUpper();
            texts[2].text = Player.Coins.ToString();
            texts[1].text = "<b>High Score: <color=#e5c100>" + Player.GetBestScore().ToString() + "</color></b>";
            Instantiate(playerInterface, new Vector3(180, 45), Quaternion.identity, gameObject.transform);
        }
        else
        {
            
            texts[0].text = leftText;
            texts[2].text = rightText;
            texts[1].text = "<b>High Score: <color=#e5c100>" + Player.GetBestScore().ToString() + "</color></b>";

            Instantiate(playerInterface, new Vector3(180, 45), Quaternion.identity, gameObject.transform);

        }

    }

    // Update is called once per frame
    void Update () {
	
	}

}
