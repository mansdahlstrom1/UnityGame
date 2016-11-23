using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace DBConnector
{
    public class DBController
    {
        private string BaseURL = "http://81.186.252.203/webservice/api.php/v2/";

        public List<Upgrade> GetAllUpgrades()
        {
            string url = BaseURL + "getAllUpgrades";
            string json = new WebClient().DownloadString(url);
            if (json == "\"No Upgrades Found\"")
            {
                return new List<Upgrade>();
            }
            string newJson = "{\"Items\":" + json + "}";
            UpgradeData[] upgradeDataList;
            upgradeDataList = JsonHelper.FromJson<UpgradeData>(newJson);
            List<Upgrade> allUpgrades = new List<Upgrade>();
            for (var i = 0; i < upgradeDataList.Length; i++)
            {
                UpgradeData ud = upgradeDataList[i];
                Upgrade u = ud.GetUpgrade();
                allUpgrades.Add(u);
            }
            return allUpgrades;
        }

        public void GetUserByUsername(string username)
        {
            string url = BaseURL + "findUserByUsername/" + username;
            string json = new WebClient().DownloadString(url);
            PersonData pd = JsonUtility.FromJson<PersonData>(json);
            pd.GetPlayer();
        }

        public Options GetUserOptions(string username)
        {
            string url = BaseURL + "findUserOptions/=" + username;
            var json = new WebClient().DownloadString(url);
            OptionData od = JsonUtility.FromJson<OptionData>(json);
            Options userOptions = od.GetOptions();
            return userOptions;
        }

        public List<Round> GetPlayerRounds(string username)
        {
            string url = BaseURL + "findUserRounds/" + username;
            string json = new WebClient().DownloadString(url);
            if (json == "\"No Rounds found\"")
            {
                return new List<Round>();
            }
            string newJson = "{\"Items\":" + json + "}";
            RoundData[] roundDataList;
            roundDataList = JsonHelper.FromJson<RoundData>(newJson);
            List<Round> playerRounds = new List<Round>();

            for (var i = 0; i < roundDataList.Length; i++)
            {
                RoundData rd = roundDataList[i];
                Round r = rd.GetRound();
                playerRounds.Add(r);
            }
            return playerRounds;
        }

        public List<Upgrade> GetPlayerUpgrades(string username)
        {
            string url = BaseURL + "findUserUpgrades/" + username;
            string json = new WebClient().DownloadString(url);
            if (json == "\"No Upgrades Found\"") 
            {
                return new List<Upgrade>();
            }
            string newJson = "{\"Items\":" + json + "}";
            UpgradeData[] upgradeDataList;
            upgradeDataList = JsonHelper.FromJson<UpgradeData>(newJson);
            List<Upgrade> playerUpgrades = new List<Upgrade>();

            for (var i = 0; i < upgradeDataList.Length; i++)
            {
                UpgradeData ud = upgradeDataList[i];
                Upgrade u = ud.GetUpgrade();
                playerUpgrades.Add(u);
            }
            return playerUpgrades;
        }

        public void GetCompletePlayer(string username)
        {
            GetUserByUsername(username);
            //Options op = GetUserOptions(username);
            Player.PlayerRounds = GetPlayerRounds(username);
            List<Upgrade> pu = GetPlayerUpgrades(username);
           
            // here we need to check a local file for settings;
            Player.Options = new Options();
      
            if (pu != null)
            {
                Player.PlayerUpgrades = pu;
            } else
            {
                Player.PlayerUpgrades = new List<Upgrade>();
            }
        }

        public void CreateRound(Round r, string username)
        {
            string url = BaseURL +
                "createRound" +
                "/" + username +
                "/" + r.Score +
                "/" + r.Duration +
                "/" + r.Coins;
           
            string result = new WebClient().DownloadString(url);

        }

        public void CreateUser(string username, string password)
        {
            Byte[] data = System.Text.Encoding.UTF8.GetBytes(password);
            Byte[] hash = new SHA256CryptoServiceProvider().ComputeHash(data);
            string hashString = Convert.ToBase64String(hash);

            hashString = hashString.Replace("/", "-");

            string url = BaseURL +
                "createUser" +
                "/" + username +
                "/" + hashString;
            string result = new WebClient().DownloadString(url);
            GetCompletePlayer(username);
        }

        public void buyUpgrade(string upgradeName)
        {
            string url = BaseURL + "buyUpgrade/" + Player.Username + "/" + upgradeName;
            string result = new WebClient().DownloadString(url);
        }

        public void equipUpgrade(string upgradeName)
        {
            string url = BaseURL + "equipUpgrade/" + Player.Username + "/" + upgradeName;
            string result = new WebClient().DownloadString(url);
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
        public string active_upgrade;


        public void GetPlayer()
        {
            Player.Username = username;
            Player.Hash = hash;
            Player.Created = created;
            Player.Activty = activity;
            Player.Coins = coins;
            Player.Active_upgrade = active_upgrade;
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
        public int cost;

        public Upgrade GetUpgrade()
        {
            Upgrade u = new Upgrade();
            u.UpgradeName = upgradeName;
            u.Cost = cost;
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
      

        public Round GetRound()
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

    public static class JsonHelper
    {
        public static T[] FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(T[] array)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = array;
            return UnityEngine.JsonUtility.ToJson(wrapper);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }
}