using System;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

namespace DBConnector
{
    public class DBController
    {
        private string BaseURL = "http://81.186.252.203/webservice/VetrarbrautinWebService.php?";


        public Player GetUserByUsername(string username)
        {
            string url = BaseURL + "op=findUserByUsername&username=" + username;
            string json = new WebClient().DownloadString(url);
            PersonData pd = JsonUtility.FromJson<PersonData>(json);
            Player p = pd.GetPlayer();
            return p;
        }

        public Options GetUserOptions(string username)
        {
            string url = BaseURL+"op=findUserOptions&username=" + username;
            var json = new WebClient().DownloadString(url);
            OptionData od = JsonUtility.FromJson<OptionData>(json);
            Options userOptions = od.GetOptions();
            return userOptions;
        }

        public List<Round> getPlayerRounds(string username)
        {
            string url = BaseURL + "op=findUserRounds&username=" + username;
            var json = new WebClient().DownloadString(url);
            RoundDataList rounds = JsonUtility.FromJson<RoundDataList>(json);

            List<Round> playerRounds = new List<Round>();
            //for (var i = 0; i < rounds.roundList.Count; i++)
            for (var i = 0; i < rounds.roundList.Length; i++)
            {
                RoundData rd = rounds.roundList[i];
                Round r = rd.getRound();
                playerRounds.Add(r);
            }
            return playerRounds;
        }

        public Player GetCompletePlayer(string username)
        {
            Player p = GetUserByUsername(username);
            p.Options = GetUserOptions(username);
            p.PlayerRounds = getPlayerRounds(username);
            return p;
        }


    }

    [Serializable]
    public class PersonData
    {
        public string username;
        public string hash;
        public DateTime created;
        public DateTime activity;
        public int coins;
        public bool isAdmin;


        public Player GetPlayer()
        {
            Player p = new Player();
            p.Username = username;
            p.Hash = hash;
            p.Created = created;
            p.Activty = activity;
            p.Coins = coins;
            p.IsAdmin = isAdmin;
            return p;
        }
    }

    [Serializable]
    public class OptionData
    {
        public int key_down;
        public int key_left;
        public int key_right;
        public int key_shoot;
        public int key_up;
        public int master_sound;

        public Options GetOptions()
        {
            Options o = new Options();
            o.Key_down = key_down;
            o.Key_left = key_left;
            o.Key_right = key_right;
            o.Key_up = key_up;
            o.Key_shoot = key_shoot;
            return o;
        }
    }

    [Serializable]
    public class UpgradeData
    {
        public string upgradeName;
        public string imageUrl;
        public int cost;
        public bool equiped;

        public Upgrade GetUpgrade()
        {
            Upgrade u = new Upgrade();
            u.UpgradeName = upgradeName;
            u.ImageUrl = imageUrl;
            u.Cost = cost;
            u.Equiped = equiped;
            return u;
        }
    }

    [Serializable]
    public class RoundData
    {
        public int roundid;
        public int coins;
        public DateTime created;
        public int duration;
        public int score;
      

        public Round getRound()
        {
            Round r = new Round();
            r.Roundid = roundid;
            r.Coins = coins;
            r.Created = created;
            r.Duration = duration;
            r.Score = score;
            return r;
        }

    }

    /* [Serializable]
    public class RoundDataList
    {
        public List<RoundData> roundList;
    }
    */
    [Serializable]
    public class RoundDataList
    {
        public RoundData[] roundList;
    }


}