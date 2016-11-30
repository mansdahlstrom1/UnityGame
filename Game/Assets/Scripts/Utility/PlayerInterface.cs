using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInterface : MonoBehaviour
{

    public Text userName;
    public Text highScore;
    public Text coins;
    public Image avatar;
    public Image coinsImg;

    private Multiplayer mp = null;
    private Dictionary<string, Sprite> playerSprites;

    public string horizontalButton;
    private int index = 0;
    void Start()
    {
        playerSprites = Utils.getPlayerSprites();

    }

    public void setPlayer1()
    {
        userName.text = Player.Username;
        coins.text = Player.Coins.ToString();
        highScore.text = "<b>High Score: <color=#e5c100>" + Player.HighScore + "</color></b>";
        coinsImg.sprite = Resources.Load<Sprite>("Images/coins");
        coinsImg.enabled = true;
        horizontalButton = "Horizontal_P1";
        avatar.sprite = Resources.Load<Sprite>("Images/Ships/" + Player.Active_upgrade);
    }

    public void setMultiPlayer(Multiplayer mp)
    {
        this.mp = mp;
        userName.text = "Player " + mp.PlayerNumber;
        highScore.text = " ";
        coins.text = " ";
        coinsImg.enabled = false;
        horizontalButton = "Horizontal_P" + mp.PlayerNumber;
        avatar.sprite = Resources.Load<Sprite>("Images/Ships/" + mp.Active_upgrade);
    }

    public void changeShip(bool next)
    {

        if (next)
        {
            index++;
            if (index > Player.PlayerUpgrades.Count -1)
                index = 0;

        }
        else
        {
            index--;
            if (index < 0)
                index = Player.PlayerUpgrades.Count - 1;
        }
        if (mp == null)
        {
            string uName = Player.PlayerUpgrades[index].UpgradeName;
            avatar.sprite = Resources.Load<Sprite>("Images/Ships/" + uName);
            Player.Active_upgrade = uName;
        }
        else
        {
            string uName = Player.PlayerUpgrades[index].UpgradeName;
            avatar.sprite = Resources.Load<Sprite>("Images/Ships/" + uName);
            mp.Active_upgrade = uName;
        }

    }

    bool pressing = false;

    // Update is called once per frame
    void Update()
    {


        if (horizontalButton != null)
        {

            float direction = Input.GetAxis(horizontalButton);

            if (direction > 0 && !pressing)
            {
                pressing = true;
                changeShip(true);

            }
            else if (direction < 0 && !pressing)
            {
                pressing = true;
                changeShip(false);
            }
            else if (direction == 0)
                pressing = false;

        }
    }

}
