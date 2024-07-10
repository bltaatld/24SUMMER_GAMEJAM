using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CurrentGameStateManager : MonoBehaviour
{
    public GameObject[] stages;

    public void Start()
    {
        Instantiate(stages[ScoreManager.instance.savedCurrentStage]); // Spawn Prefab stage
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            BackToMain();
        }
    }

    public void BackToMain()
    {
        Time.timeScale = 1.0f; //Restart Time

        // Pause Behavior
        ScoreManager.instance.currentCoin = 0;
        ScoreManager.instance.SaveClearValue();
        CurrentSceneManager.instance.loadNamedScene("MenuScene");
    }

    public void RestartStage()
    {
        Time.timeScale = 1.0f; //Restart Time
        CurrentSceneManager.instance.ReloadScene();
    }

    public void NextStage()
    {
        Time.timeScale = 1.0f; //Restart Time

        // Save Current Info
        ScoreManager.instance.savedCurrentStage += 1;
        ScoreManager.instance.SaveClearValue();
        
        CurrentSceneManager.instance.ReloadScene(); // Load Next Scene
    }

    public void HostageSave(string str)
    {
        Time.timeScale = 1.0f; //Restart Time
        ScoreManager.instance.ActiveHostageData(ScoreManager.instance.currentHostage);

        // Save Current Info
        ScoreManager.instance.savedCurrentStage += 1;
        ScoreManager.instance.currentHostage += 1;
        CurrentSceneManager.instance.loadNamedScene(str); // Load Next Scene
    }

    public void NextStageString(string str)
    {
        Time.timeScale = 1.0f; //Restart Time

        // Save Current Info
        ScoreManager.instance.savedCurrentStage += 1;
        ScoreManager.instance.currentHostage += 1;
        CurrentSceneManager.instance.loadNamedScene(str); // Load Next Scene
    }
}
