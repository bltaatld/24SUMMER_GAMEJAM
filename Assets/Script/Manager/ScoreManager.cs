using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    [Header("Values")]
    public int currentCoin;
    public int savedCurrentStage;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    } //Get instance & Don't Destory On Load

    public void ResetValue()
    {
        currentCoin = 0;
    }
}
