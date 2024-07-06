using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if (collision.CompareTag("Player"))
        {
            CurrentSceneManager.instance.ReloadScene();
        }
    }
}
