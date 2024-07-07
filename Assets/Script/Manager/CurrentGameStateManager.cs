using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class CurrentGameStateManager : MonoBehaviour
{
    public GameObject[] stages;

    public void Start()
    {
        Instantiate(stages[ScoreManager.instance.savedCurrentStage]);
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            // Pause Control
            ScoreManager.instance.currentCoin = 0;
            CurrentSceneManager.instance.loadNamedScene("MenuScene");
        }
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
}
