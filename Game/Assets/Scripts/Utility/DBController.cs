using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace DBConnector
{
    public static class DBController
    {
        private static string BaseURL = "http://89.236.60.99/webservice/api.php/v2/";

        public static string downloadContent(string url)
        {
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            timer.Start();
            WWW www = new WWW(url);
            Debug.Log("bytes downloaded ("+url+"): " +Utils.convertByte(www.bytesDownloaded) );
            if(www == null)
            {
                Debug.Log("WWW is null");
            }
            while (!www.isDone)
            {
                Debug.Log("waiting for www request to finish....");
            }
            timer.Stop();
            Debug.Log("Respone Time: " + timer.ElapsedMilliseconds);
            return www.text;
        }

        public static List<Upgrade> GetAllUpgrades()
        {
            string url = BaseURL + "getAllUpgrades";

            string json = downloadContent(url);
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

        public static void GetUserByUsername(string username)
        {
            string url = BaseURL + "findUserByUsername/" + username;
            string json = downloadContent(url);
            PersonData pd = JsonUtility.FromJson<PersonData>(json);
            pd.GetPlayer();
        }

        public static void GetUserHighScore()
        {
            string url = BaseURL + "getUserHighScore/" + Player.Username;
            string json = downloadContent(url);
            if (json != "null")
            {
                Player.HighScore = int.Parse(json.Split(':')[1].TrimEnd('}')); // Das super ugly hack
            }
            else
            {
                Player.HighScore = 0;
            }
        }

        public static List<Round> GetPlayerRounds(string username)
        {
            string url = BaseURL + "findUserRounds/" + username;
            string json = downloadContent(url);
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

        public static List<Upgrade> GetPlayerUpgrades(string username)
        {
            string url = BaseURL + "findUserUpgrades/" + username;
            string json = downloadContent(url);
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

        public static void GetCompletePlayer(string username)
        {
            GetUserByUsername(username);
            GetUserHighScore();
            List<Upgrade> pu = GetPlayerUpgrades(username);
      
            if (pu != null)
            {
                Player.PlayerUpgrades = pu;
            } else
            {
                Player.PlayerUpgrades = new List<Upgrade>();
            }
        }

        public static void CreateRound(Round r, string username)
        {
            string url = BaseURL +
                "createRound" +
                "/" + username +
                "/" + r.Score +
                "/" + r.Duration +
                "/" + r.Coins;
           
            string result = downloadContent(url);

        }

        public static void CreateUser(string username, string password)
        {
            Byte[] data = System.Text.Encoding.UTF8.GetBytes(password);
            Byte[] hash = new SHA256CryptoServiceProvider().ComputeHash(data);
            string hashString = Convert.ToBase64String(hash);

            hashString = hashString.Replace("/", "-");

            string url = BaseURL +
                "createUser" +
                "/" + username +
                "/" + hashString;
            string result = downloadContent(url);
            GetCompletePlayer(username);
        }

        public static void buyUpgrade(string upgradeName)
        {
            upgradeName = upgradeName.Replace(" ", "%20");
            string url = BaseURL + "buyUpgrade/" + Player.Username + "/" + upgradeName;
            Debug.Log(url);
            string result = downloadContent(url);
            Debug.Log(result);
        }

        public static void equipUpgrade(string upgradeName)
        {
            upgradeName = upgradeName.Replace(" ", "%20");
            string url = BaseURL + "equipUpgrade/" + Player.Username + "/" + upgradeName;
            Debug.Log(url);
            string result = downloadContent(url);
            Debug.Log(result);
        }

        public static List<HighScore> getHighScores()
        {
            List<HighScore> HighScores = new List<HighScore>();
            string url = BaseURL + "getHighScores";
            string json = downloadContent(url);
            string newJson = "{\"Items\":" + json + "}";
            HighScoreData[] highScoreList = JsonHelper.FromJson<HighScoreData>(newJson);
            foreach(HighScoreData hsd in highScoreList)
            {
                HighScore h = hsd.getHighScore();
                HighScores.Add(h);
            }
            return HighScores;


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
            return JsonUtility.ToJson(wrapper);
        }

        [Serializable]
        private class Wrapper<T>
        {
            public T[] Items;
        }
    }
}
