using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreManager.instance.currentKill += 1;
            AudioManager.instance.PlaySound(3);

            animator.SetTrigger("IsDead");
        }
    }

    public void DeadAction()
    {
        Destroy(gameObject);
    }
}
