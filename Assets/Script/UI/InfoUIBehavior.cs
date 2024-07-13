using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InfoUIBehavior : MonoBehaviour
{
    public TextMeshProUGUI coinText;
    public TextMeshProUGUI killText;
    public TextMeshProUGUI hostageText;
    public GameObject sceneManager;

    private void Start()
    {
        sceneManager = GameObject.Find("GameManager");
    }

    private void Update()
    {
        killText.text = ScoreManager.instance.currentKill.ToString();
        coinText.text = ScoreManager.instance.clearCoin.ToString();
        hostageText.text = ScoreManager.instance.currentHostage.ToString();
    }

    public void GameStart()
    {
        sceneManager.GetComponent<CurrentSceneManager>().loadNamedScene("GameScene");
    }
}
