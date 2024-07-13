using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClearManager : MonoBehaviour
{
    public bool[] resetValue;

    public void ResetGame()
    {
        ScoreManager.instance.ResetAllValue(resetValue);
        SaveManager.instance.SaveData(0, 0, 0, 0, resetValue);
        CurrentSceneManager.instance.loadNamedScene("MenuScene");
    }
}
