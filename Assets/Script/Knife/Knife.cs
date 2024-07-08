using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    Rigidbody2D rigid2D;
    CapsuleCollider2D capsuleCollider2D;


    private void Awake()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }

    public void KnifeMove(bool isMoving)
    {
        if (isMoving)
        {
            Vector2 movement = new Vector2(1, 0);

            rigid2D.AddForce(movement);
        }
    }
}
