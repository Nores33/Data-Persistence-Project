using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistenceManager : MonoBehaviour
{
    public static PersistenceManager Instance;

    public int highScore;
    public string highScorePlayer;

    public string player;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadInfo();
    }

    [System.Serializable]
    class SaveData
    {
        public int HighScore;
        public string HighScorePlayer;
    }

    public void SaveInfo()
    {
        SaveData data = new SaveData();
        data.HighScore = highScore;
        data.HighScorePlayer = highScorePlayer;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadInfo()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.HighScore;
            highScorePlayer = data.HighScorePlayer;
        }
    }
}
