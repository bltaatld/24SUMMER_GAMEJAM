using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombTile : MonoBehaviour
{
    [Header("Value")]
    public float cooltime;
    public float currentTime;
    public float detectionRadius = 5.0f;
    public bool isTouched;

    [Header("Components")]
    public LayerMask detectionLayer;
    public List<GameObject> nearbyObjects = new List<GameObject>();


    private void Update()
    {
        CheckForNearbyObjects();

        if (isTouched) // if Player collide, start timer
        {
            currentTime += Time.deltaTime;
        }

        if (currentTime >= cooltime)
        {
            foreach (GameObject obj in nearbyObjects)
            {
                // 'CanExplode' Object Explode Behavior
                obj.SetActive(false);
            }

            // Reset Behavior
            currentTime = 0;
            isTouched = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isTouched = true;
        }
    }

    public void CheckForNearbyObjects() // Check Nearby 'CanExplode' Object
    {
        nearbyObjects.Clear();
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, detectionLayer);

        foreach (Collider2D collider in colliders)
        {
            nearbyObjects.Add(collider.gameObject);
        }
    }

    public void OnDrawGizmosSelected() // Draw DetectRadius
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
