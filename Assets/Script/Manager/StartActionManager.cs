using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartActionManager : MonoBehaviour
{
    public GameObject startAction;

    void Start()
    {
        startAction.SetActive(true);
    }

    public void DisActiveAction()
    {
        startAction.SetActive(false);
    }
}
