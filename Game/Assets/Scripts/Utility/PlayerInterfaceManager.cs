using UnityEngine;
using System.Collections.Generic;

public class PlayerInterfaceManager : MonoBehaviour {

    public PlayerInterface playerInterface;
    private Dictionary<int, PlayerInterface> multiPlayerPanes;
	// Use this for initialization
	void Start () {
        multiPlayerPanes = new Dictionary<int, PlayerInterface>();
        playerInterface.setPlayer1();
        RecreatePlayerInterface();
    }

    public void RecreatePlayerInterface()
    {
        foreach (Multiplayer mp in Player.MultiPlayers.Values){
            RectTransform piRect = playerInterface.GetComponent<RectTransform>();
            Vector3 pos = piRect.transform.position;
            // Ignore stupid calc;
            pos.x += (piRect.rect.width * (mp.PlayerNumber - 1)) + 100 * (mp.PlayerNumber - 1);
            PlayerInterface Multiplayer1 = Instantiate(playerInterface, pos, Quaternion.identity, gameObject.transform) as PlayerInterface;
            Multiplayer1.setMultiPlayer(mp);
            multiPlayerPanes.Add(mp.PlayerNumber, Multiplayer1);
        }

    }
    public void newPlayerInterface(Multiplayer mp)
    {
        if (!multiPlayerPanes.ContainsKey(mp.PlayerNumber))
        {
            RectTransform piRect = playerInterface.GetComponent<RectTransform>();
            Vector3 pos = piRect.transform.position;
            // Ignore stupid calc;
            pos.x += (piRect.rect.width * (mp.PlayerNumber - 1)) + 100 * (mp.PlayerNumber - 1);
            PlayerInterface Multiplayer1 = Instantiate(playerInterface, pos, Quaternion.identity, gameObject.transform) as PlayerInterface;
            Multiplayer1.setMultiPlayer(mp);
            multiPlayerPanes.Add(mp.PlayerNumber, Multiplayer1);
        }


    }


    // Update is called once per frame
    void Update () {
       // Lägg till Multiplayer
       if (Player.MultiPlayers.Count < 3)
        {
            for (int i = 2; i <= 4; i++)
            {
                if (Input.GetButtonDown("Start_P" + i))
                {
                   if(!Player.MultiPlayers.ContainsKey(i))
                    { 
                        Multiplayer mp = new Multiplayer(i, Player.Active_upgrade);
                        Player.MultiPlayers[i] = mp;
                        newPlayerInterface(mp);
                    }
                }
            }
        }
    }
}
