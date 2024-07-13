using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCheckManager : MonoBehaviour
{
    public List<GameObject> objectsInCollider = new List<GameObject>();
    private GameObject enemyObject;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            objectsInCollider.Add(collision.gameObject);
            // Debug.Log("Enemy entered: " + collision.gameObject.name); // Debug Check Enemy In Position
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            objectsInCollider.Remove(collision.gameObject);
        }

        if (objectsInCollider.Count == 0)
        {
            Debug.Log("All objects have exited the collider.");

            // Find 'StageClear' Object and Active
            GameObject parentObject = GameObject.Find("UI_InGameMenu");

            Transform parentTransform = parentObject.transform;
            Transform childTransform = parentTransform.Find("StageClear");

            childTransform.gameObject.SetActive(true);

            Time.timeScale = 0f; // Pause Time when UI Active
        }
    }
}
