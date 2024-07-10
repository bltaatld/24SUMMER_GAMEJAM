using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class GameData
{
    //Stage System
    public int currentCoin;
    public int clearCoin;
    public int savedCurrentStage;

    //Hostage System
    public int currentHostage;
    public int currentKill;
    public bool[] hostageSaved;

    public GameData()
    {
        hostageSaved = new bool[4];
    }
}

public class SaveManager : MonoBehaviour
{
    private string dataPath;
    public static SaveManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    } //Get instance & Don't Destory On Load


    void Start()
    {
        dataPath = Path.Combine(Application.persistentDataPath, "gamedata.json");
        Debug.Log(dataPath);
    }

    public void SaveData(int clearcoin, int savedCurrentStage,int currentKill, int currentHostage, bool[] isSaved)
    {
        GameData data = new GameData();
        data.clearCoin = clearcoin;
        data.savedCurrentStage = savedCurrentStage;
        data.currentHostage = currentHostage;
        data.currentKill = currentKill;

        for (int i=0; i <= 3; i++)
        {
            data.hostageSaved[i] = isSaved[i];
        }

        string json = JsonUtility.ToJson(data, true);

        Debug.Log(dataPath);
        File.WriteAllText(dataPath, json);
    }

    public GameData LoadData()
    {
        dataPath = Path.Combine(Application.persistentDataPath, "gamedata.json");

        if (File.Exists(dataPath))
        {
            string json = File.ReadAllText(dataPath);
            GameData data = JsonUtility.FromJson<GameData>(json);

            ScoreManager.instance.clearCoin = data.clearCoin;
            ScoreManager.instance.savedCurrentStage = data.savedCurrentStage;
            ScoreManager.instance.currentHostage = data.currentHostage;
            ScoreManager.instance.currentKill = data.currentKill;

            for (int i = 0; i <= 3; i++)
            {
                ScoreManager.instance.isSaved[i] = data.hostageSaved[i];
            }

            Debug.Log("Loaded data: clearCoin = " + data.clearCoin + ", savedCurrentStage = " + data.savedCurrentStage);
            return data;
        }
        else
        {
            Debug.Log(dataPath);
            Debug.LogWarning("Save file not found!");
            return null;
        }
    }
}
