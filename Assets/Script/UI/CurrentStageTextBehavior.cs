using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurrentStageTextBehavior : MonoBehaviour
{
    public CurrentGameStateManager stageManger;
    public TextMeshProUGUI stageText;
    public TextMeshProUGUI stageEndText;
    public TextMeshProUGUI stageEndText2;

    private void Update()
    {
        stageText.text = stageManger.stages[ScoreManager.instance.savedCurrentStage].name;
        stageEndText.text = stageManger.stages[ScoreManager.instance.savedCurrentStage].name;
        stageEndText2.text = stageManger.stages[ScoreManager.instance.savedCurrentStage].name;
    }
}
