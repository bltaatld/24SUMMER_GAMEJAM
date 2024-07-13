using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class ShootEnemyBehavior : MonoBehaviour
{
    public Animator animator;
    public LayerMask obstacleLayer;
    public float raycastDistance = 1f;

    private void Update()
    {
        CheckPlayerCollide(Vector2.up);
        CheckPlayerCollide(Vector2.down);
        CheckPlayerCollide(Vector2.left);
        CheckPlayerCollide(Vector2.right);
    }

    public void CheckPlayerCollide(Vector2 direction)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, raycastDistance, obstacleLayer);

        if (hit.collider != null)
        {
            if (direction == Vector2.up)
            {
                transform.rotation = Quaternion.Euler(0, 0, 180);
            }
            else if (direction == Vector2.down)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
            else if (direction == Vector2.left)
            {
                transform.rotation = Quaternion.Euler(0, 0, -90);
            }
            else if (direction == Vector2.right)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90);
            }

            Debug.DrawRay(transform.position, direction * raycastDistance, Color.red);
            animator.SetTrigger("IsAttack");
        }
        else
        {
            Debug.DrawRay(transform.position, direction * raycastDistance, Color.green);
        }
    }
}
