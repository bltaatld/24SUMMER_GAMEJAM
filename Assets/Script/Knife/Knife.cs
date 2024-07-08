using UnityEngine;

public class Knife : MonoBehaviour
{
    private Rigidbody2D rigid2D;
    private CapsuleCollider2D capsuleCollider2D;
    private float knifeSpeed = 3;
    [HideInInspector] public bool isMoving;
    private void Awake()
    {
        isMoving = false;
        rigid2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }
    private void Update()
    {
        if (gameObject.transform.position.y >= 10)
        {
            Destroy(gameObject);
        }
        if (isMoving)
        {
            Vector2 movement = new Vector2(0, 10);
            rigid2D.AddForce(movement * knifeSpeed);
        }
    }
}
