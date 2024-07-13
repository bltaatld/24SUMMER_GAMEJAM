using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShootEnemyBehavior : MonoBehaviour
{
    [Header("Components")]
    private Transform playerTransform;
    public Transform aimTarget;
    public Transform shootPoint;
    public DrawLineToPlayer aimLine;
    public GameObject projectliePrefab;
    private GameObject aimTargetSprite;

    [Header("Rotation Settings")]
    public float shootInterval = 1.0f;
    private bool isDetected = false;
    private bool isInRange = false;
    private Vector2 currentDirection;

    void Start()
    {
        playerTransform = GameObject.Find("Player").transform;
        aimTargetSprite = aimLine.lineObject;

        StartCoroutine(ShootRoutine());
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

    void Update()
    {
        if (playerTransform != null)
        {
            RotateTowardsPlayer();
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

    private void RotateTowardsPlayer()
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

    private void ShootProjectile()
    {
        AudioManager.instance.PlaySound(6);

        if (projectliePrefab != null && shootPoint != null)
        {
            GameObject projectile = Instantiate(projectliePrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.velocity = currentDirection * 12.5f;
            }

            isDetected = false;
        }
    }
}
