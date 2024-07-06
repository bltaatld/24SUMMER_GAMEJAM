using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShootEnemyBehavior : MonoBehaviour
{
    [Header("Components")]
    private Transform playerTransform;
    public Transform aimTarget;
    public Transform shootPoint;
    public GameObject aimTargetSprite;
    public GameObject projectliePrefab;

    [Header("Rotation Settings")]
    public float shootInterval = 1.0f;
    private bool isDetected = false;
    private bool isInRange = false;
    private Vector2 currentDirection;

    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        StartCoroutine(ShootRoutine());
    }

    void Update()
    {
        if (playerTransform != null)
        {
            AdjustRotationBasedOnPlayerPosition();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    void AdjustRotationBasedOnPlayerPosition()
    {
        Vector2 directionToPlayer = playerTransform.position - transform.position;

        if (isInRange == true || isDetected)
        {
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            aimTarget.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90f));
            currentDirection = directionToPlayer.normalized;
            aimTargetSprite.SetActive(true);

            isDetected = true;
        }
        else
        {
            aimTargetSprite.SetActive(false);
        }
    }

    IEnumerator ShootRoutine()
    {
        while (true)
        {
            if (isDetected)
            {
                ShootProjectile();
            }
            yield return new WaitForSeconds(shootInterval);
        }
    }

    void ShootProjectile()
    {
        if (projectliePrefab != null && shootPoint != null)
        {
            GameObject projectile = Instantiate(projectliePrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = currentDirection * 25f;
            }

            isDetected = false;
        }
    }
}
