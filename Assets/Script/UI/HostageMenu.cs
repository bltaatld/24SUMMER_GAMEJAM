using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostageMenu : MonoBehaviour
{
    public GameObject[] hostageUI;

    public void Update()
    {
        for(int i=0; i < ScoreManager.instance.isSaved.Length; i++)
        {
            hostageUI[i].SetActive(ScoreManager.instance.isSaved[i]);
        }
    }
}
