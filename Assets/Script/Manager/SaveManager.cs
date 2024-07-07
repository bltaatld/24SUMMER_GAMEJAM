using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class GameData
{
    public int currentCoin;
    public int clearCoin;
    public int savedCurrentStage;
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

    public void SaveData(int clearcoin, int savedCurrentStage)
    {
        GameData data = new GameData();
        data.clearCoin = clearcoin;
        data.savedCurrentStage = savedCurrentStage;

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
