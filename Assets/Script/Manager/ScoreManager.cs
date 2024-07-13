using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [Header("Values")]
    public int currentCoin;
    public int clearCoin;
    public int savedCurrentStage;
    public int currentHostage;
    public int currentKill;
    public bool[] isSaved;

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

    private void Start()
    {
        SaveManager.instance.LoadData(); // On Game Start Load Saved Data
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SaveManager.instance.SaveData(clearCoin, savedCurrentStage, currentKill, currentHostage, isSaved); // Quit or Return to Menu, Save Player Data
        }
    }

    public void OnApplicationQuit()
    {
        SaveManager.instance.SaveData(clearCoin, savedCurrentStage, currentKill, currentHostage, isSaved); // Quit or Return to Menu, Save Player Data
    }

    public void ResetValue()
    {
        currentCoin = 0;
    }

    public void ResetAllValue(bool[] resetData) 
    {
        currentCoin = 0;
        clearCoin = 0;
        savedCurrentStage = 0;
        currentHostage = 0;
        currentKill = 0;
        isSaved = resetData;
    }

    public void SaveClearValue() // When Game Clear, Update Save Data 
    {
        clearCoin += currentCoin;
        SaveManager.instance.SaveData(clearCoin, savedCurrentStage, currentKill, currentHostage, isSaved); // Quit or Return to Menu, Save Player Data
    }

    public void ActiveHostageData(int i)
    {
        isSaved[i] = true; //If Hostage[i] Saved, set true
    }
}
