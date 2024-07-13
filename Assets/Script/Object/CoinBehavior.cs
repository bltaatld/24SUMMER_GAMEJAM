using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBehavior : MonoBehaviour
{
    public Animator animator;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            AudioManager.instance.PlaySound(2);
            animator.SetTrigger("IsDead");
        }
    }

    public void DeadAction()
    {
        Destroy(gameObject);
    }
}
