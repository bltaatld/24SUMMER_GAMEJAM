using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentStageTextBehavior : MonoBehaviour
{
    public CurrentGameStateManager stageManger;
    public TextMeshProUGUI stageText;
    public TextMeshProUGUI stageEndText;

    private void Start()
    {
        stageText.text = stageManger.stages[ScoreManager.instance.savedCurrentStage].name;
        stageEndText.text = stageManger.stages[ScoreManager.instance.savedCurrentStage].name;
    }
}
