using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentGameStateManager : MonoBehaviour
{
    public GameObject[] stages;

    public void Start()
    {
        Instantiate(stages[ScoreManager.instance.savedCurrentStage]);
    }
}
