using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerInterface : MonoBehaviour {

    public Text userName;
    public Text highScore;
    public Text coins;
    public Image avatar;
    public Image coinsImg;

    public string horizontalButton;

	void Start () {
       
    }

    public void setPlayer1()
    {
        userName.text = Player.Username;
        coins.text = Player.Coins.ToString();
        highScore.text = "<b>High Score: <color=#e5c100>" + Player.GetBestScore().ToString() + "</color></b>";
        coinsImg.sprite = Resources.Load<Sprite>("Images/coins");
        coinsImg.enabled = true;
        horizontalButton = "Horizontal_P1";
        avatar.sprite = Resources.Load<Sprite>("Images/Ships/" + Player.Active_upgrade);
}

    public void setMultiPlayer(Multiplayer mp)
    {
        userName.text = "Player " + mp.PlayerNumber;
        highScore.text = " ";
        coins.text = " ";
        coinsImg.enabled = false;
        horizontalButton = "Horizontal_P" + mp.PlayerNumber;
        avatar.sprite = Resources.Load<Sprite>("Images/Ships/" + mp.Active_upgrade);
   
       
    }

    // Update is called once per frame
    void Update()
    {
        if (horizontalButton != null)
        {
            if (Input.GetButton(horizontalButton))
            {
                Debug.Log(Input.GetAxis(horizontalButton));
                // this.avatar = next image in list;
            }

        }
    }
}
