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
            SaveManager.instance.SaveData(clearCoin, savedCurrentStage); // Quit or Return to Menu, Save Player Data
        }
    }

    public void OnApplicationQuit()
    {
        SaveManager.instance.SaveData(clearCoin, savedCurrentStage); // Quit or Return to Menu, Save Player Data
    }

    public void ResetValue()
    {
        currentCoin = 0;
    }

    public void SaveClearValue() // When Game Clear, Update Save Data 
    {
        clearCoin += currentCoin;
    }
}
