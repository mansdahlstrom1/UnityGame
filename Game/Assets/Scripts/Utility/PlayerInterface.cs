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
    

    DBConnector.DBController db = new DBConnector.DBController();



    // Use this for initialization

    void Start () {
        if (Player.Username != null)
        {
            db.GetCompletePlayer(Player.Username);
            Debug.Log(Player.Active_upgrade);
        }
        playerInterface = Resources.Load<GameObject>("Prefabs/Misc/PlayerInterface");
        PlayerShip ps1 = Resources.Load<PlayerShip>("Prefabs/Player/Ships/" + Player.Active_upgrade);
        PlayerShip ps = Instantiate(ps1, new Vector3(-130,0), Quaternion.identity, playerInterface.transform) as PlayerShip;
        ps.transform.localScale = new Vector3(0.4f, 0.4f, 1);
        float width = playerInterface.GetComponent<RectTransform>().rect.width;
        float height = playerInterface.GetComponent<RectTransform>().rect.height;
        Vector3 psTransform = new Vector3((width / 2) -800f, (height / 2) -450f);

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

            Instantiate(playerInterface, psTransform, Quaternion.identity, gameObject.transform);

        }

    }

    // Update is called once per frame
    void Update () {
	
	}

}
