using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    static public MenuManager instance;
    public string playerName;
    public string bestPlayerName = "";
    public int bestScore = 0;

    void Awake()
    {
        if (MenuManager.instance)
        {
            Destroy(gameObject);
        }
        else
        {
            MenuManager.instance = this;
            // scene 共享
            DontDestroyOnLoad(gameObject);
        }
        // 还原 session
        LoadData();
    }

    [System.Serializable]
    class UserData
    {
        public string playerName;
        public string bestPlayerName;
        public int bestScore;
    }

    public void SaveData()
    {
        var data = new UserData
        {

            playerName = playerName,
            bestPlayerName = bestPlayerName,
            bestScore = bestScore
        };
        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            var data = JsonUtility.FromJson<UserData>(json);

            playerName = data.playerName;
            bestPlayerName = data.bestPlayerName;
            bestScore = data.bestScore;
        }
    }
}
