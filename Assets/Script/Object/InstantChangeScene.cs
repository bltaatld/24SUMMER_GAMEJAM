using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantChangeScene : MonoBehaviour
{
    public string sceneName;

    private void OnEnable()
    {
        CurrentSceneManager.instance.loadNamedScene(sceneName);
        Debug.Log("SceneChange");
    }

}
