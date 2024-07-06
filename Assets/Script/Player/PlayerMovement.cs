using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Components")]
    public Rigidbody2D targetRigidbody;
    public LayerMask wallLayer;

    [Header("MovementValues")]
    public float moveForce = 5.0f;
    public float stopThreshold = 0.1f;

    #region PrivateValue
    private Vector3 mouseStartPos;
    private Vector3 mouseEndPos;
    private bool isDragging = false;
    private bool isMoving = false;
    #endregion

    void Update()
    {
        if (isMoving) //check isMoving
        {
            if (targetRigidbody.velocity.magnitude < stopThreshold)
            {
                isMoving = false;
            }
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            mouseStartPos = Input.mousePosition;
            isDragging = true;
        }

        if (Input.GetMouseButtonUp(0) && isDragging)
        {
            mouseEndPos = Input.mousePosition;
            isDragging = false;
            DetectDragDirection();
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

        MoveObject(direction);
    }

    private void MoveObject(Vector2 direction) //Move Player Object Straight
    {
        if (targetRigidbody != null)
        {
            targetRigidbody.velocity = Vector2.zero; //normalize
            targetRigidbody.AddForce(direction.normalized * moveForce, ForceMode2D.Impulse);
            isMoving = false;
        }
    }
}
