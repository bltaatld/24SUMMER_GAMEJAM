using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostageManager : MonoBehaviour
{
    public LockBehaviour lockBehaviour;

    void Awake()
    {
        UpdateHostageInfo();
    }

    public void UpdateHostageInfo()
    {
        if (ScoreManager.instance.currentHostage == 0)
        {
            lockBehaviour.numberOfLocks = 2;
        }

        if (ScoreManager.instance.currentHostage == 1)
        {
            lockBehaviour.numberOfLocks = 3;
        }

        if (ScoreManager.instance.currentHostage == 2)
        {
            lockBehaviour.numberOfLocks = 4;
        }

        if (ScoreManager.instance.currentHostage == 3)
        {
            lockBehaviour.numberOfLocks = 5;
        }
    }
}
