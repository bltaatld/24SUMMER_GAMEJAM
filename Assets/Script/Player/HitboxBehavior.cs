using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxBehavior : MonoBehaviour
{
    [Header("Components")]
    public GameObject hitboxTarget;
    public Animator animator;

    [Header("Value")]
    public float currentTime;
    public float coolTime;
    public bool isHit;
    public bool isTimerEnd;

    private void Update()
    {
        if (isHit)
        {
            currentTime += Time.deltaTime;
        }

        if(currentTime >= coolTime)
        {
            isTimerEnd = true;
        }

        if (isTimerEnd)
        {
            DeadAction();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            GetCoinAction();
        }

        if (collision.CompareTag("DeadTile"))
        {
            isHit = true;
            
            Debug.Log("Player Dead");
            animator.SetTrigger("IsDead");

            hitboxTarget.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    public void GetCoinAction()
    {
        ScoreManager.instance.currentCoin += 1;
    }

    public void DeadAction()
    {
        // Find 'StageRestart' Object and Active
        GameObject parentObject = GameObject.Find("UI_InGameMenu");

        Transform parentTransform = parentObject.transform;
        Transform childTransform = parentTransform.Find("StageRestart");

        childTransform.gameObject.SetActive(true);

        Time.timeScale = 0f; // Pause Time when UI Active
        isTimerEnd = false;
    }
}
