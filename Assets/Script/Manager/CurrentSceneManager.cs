using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CurrentSceneManager : MonoBehaviour
{
    public static CurrentSceneManager instance;

    private void Awake()
    {
        Application.targetFrameRate = 60;

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public void loadNamedScene(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void ReloadScene()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        Debug.Log(currentSceneName+ " Scene Reloaded");
        ScoreManager.instance.ResetValue();
        SceneManager.LoadScene(currentSceneName);
    }
}
