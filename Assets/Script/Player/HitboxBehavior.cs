using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxBehavior : MonoBehaviour
{
    [Header("Components")]
    public GameObject hitboxTarget;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            ScoreManager.instance.currentCoin += 1;
        }

        if (collision.CompareTag("DeadTile"))
        {
            Debug.Log("Player Dead");
            CurrentSceneManager.instance.ReloadScene();
        }
    }
}
