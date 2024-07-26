using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    public Animator animator;
    public Rigidbody2D targetRigidbody;
    public LayerMask obstacleLayer;

    [Header("MovementValues")]
    public float moveForce = 5.0f;
    public float stopThreshold = 0.1f;
    public float raycastDistance = 1f;
    public Vector2 cantMoveDirection;
    public bool isMoving = false;
    public bool canMoving = false;

    #region PrivateValue
    private Vector3 mouseStartPos;
    private Vector3 mouseEndPos;
    private bool isDragging = false;
    #endregion

    private void Start()
    {
        Time.timeScale = 1.0f; // When Player Active, Game Time is 1.0f
    }

    void Update()
    {
        if (isMoving && canMoving) // Check Moving State of Player
        {
            if (targetRigidbody.velocity.magnitude < stopThreshold)
            {
                CameraShake.instance.Shakecamera(2.5f, 0.2f);
                isMoving = false;
            }
            return;
        }

        if (!isMoving && canMoving) // Check Moving State of Player
        {
            if (Input.GetMouseButtonDown(0))
            {
                AudioManager.instance.PlaySound(4);

                mouseStartPos = Input.mousePosition;
                isDragging = true;
            }

            if (Input.GetMouseButtonUp(0) && isDragging)
            {
                mouseEndPos = Input.mousePosition;
                isDragging = false;

                animator.SetTrigger("IsAttack");
                DetectDragDirection();
            }
        }
    }

    public bool CheckWallCollide(Vector2 direction) // Check MoveDirection is not collide wall
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, raycastDistance, obstacleLayer);

        if (hit.collider != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void DetectDragDirection() // Detect Player Drag Input Horizontal & Vertical
    {
        float deltaX = mouseEndPos.x - mouseStartPos.x;
        float deltaY = mouseEndPos.y - mouseStartPos.y;

        Vector2 direction = Vector2.zero;

        if (Mathf.Abs(deltaX) > Mathf.Abs(deltaY))
        {
            if (deltaX > 0)
            {
                direction = Vector2.right;
            }
            else
            {
                direction = Vector2.left;
            }
        }
        else
        {
            if (deltaY > 0)
            {
                direction = Vector2.up;
            }
            else
            {
                direction = Vector2.down;
            }
        }

        if(direction != cantMoveDirection)
        {
            MoveObject(direction);
            RotateTowardsDirection(direction);
        }
    }

    private void RotateTowardsDirection(Vector2 direction)
    {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle + 90f));
    }

    private void MoveObject(Vector2 direction) // Move Player Object Straight
    {
        if (targetRigidbody != null)
        {
            if (CheckWallCollide(direction) == true)
            {
                // Debug.Log(direction); //Debug Collide Direction
                targetRigidbody.velocity = Vector2.zero; //normalize
                targetRigidbody.AddForce(direction.normalized * moveForce, ForceMode2D.Impulse);
                isMoving = true;
            }
        }
    }
}
