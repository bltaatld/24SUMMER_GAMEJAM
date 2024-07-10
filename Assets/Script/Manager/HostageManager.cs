using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class HostageManager : MonoBehaviour
{
    public LockBehaviour lockBehaviour;
    public KunaiBehaviour kunaiBehaviour;
    public void UpdateHostageInfo()
    {
        if (ScoreManager.instance.currentHostage == 0)
        {
            lockBehaviour.orbitSpeed = 60;
            lockBehaviour.numberOfLocks = 2;
            lockBehaviour.angles = new float[lockBehaviour.numberOfLocks];
            lockBehaviour.angles[0] = 0;
            lockBehaviour.angles[1] = 180;
        }

        if (ScoreManager.instance.currentHostage == 1)
        {
            lockBehaviour.orbitSpeed = 60;
            lockBehaviour.numberOfLocks = 3;
            lockBehaviour.angles = new float[lockBehaviour.numberOfLocks];
            lockBehaviour.angles[0] = 0;
            lockBehaviour.angles[1] = 60;
            lockBehaviour.angles[2] = 120;

        }

        if (ScoreManager.instance.currentHostage == 2)
        {
            lockBehaviour.orbitSpeed = 90;
            lockBehaviour.numberOfLocks = 5;
            lockBehaviour.angles = new float[lockBehaviour.numberOfLocks];
            lockBehaviour.angles[0] = 0;
            lockBehaviour.angles[1] = 60;
            lockBehaviour.angles[2] = 120;
            lockBehaviour.angles[3] = 240;
            lockBehaviour.angles[4] = 300;
            
        }

        if (ScoreManager.instance.currentHostage == 3)
        {
            lockBehaviour.orbitSpeed = 120;
            lockBehaviour.numberOfLocks = 6;
            lockBehaviour.angles = new float[lockBehaviour.numberOfLocks];
            lockBehaviour.angles[0] = 0;
            lockBehaviour.angles[1] = 60;
            lockBehaviour.angles[2] = 120;
            lockBehaviour.angles[3] = 180;
            lockBehaviour.angles[4] = 240;
            lockBehaviour.angles[5] = 300;
        }
        kunaiBehaviour.numberOfKnifes = lockBehaviour.numberOfLocks + 2;
    }
}
