using System.Collections;
using UnityEngine;

public class Kunai : MonoBehaviour
{
    
    private Rigidbody2D rigid2D;
    private CapsuleCollider2D capsuleCollider2D;
    private float kunaiSpeed = 15;
    [HideInInspector] public bool isMoving;
    [HideInInspector] public bool isUse;

    #region ShowKnife
    private float duration = 0.15f;
    private float moveDistance = 1f; // 이동할 거리 (위쪽으로 2 유닛)
    private SpriteRenderer spriteRenderer;
    private Color startColor;
    private Color endColor;
    private Vector3 startPosition;
    private Vector3 endPosition;
    #endregion

    private void Awake()
    {
        
        rigid2D = GetComponent<Rigidbody2D>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isMoving = false;
        isUse = false;
    }
    void Start()
    {
        startColor = new Color(1, 1, 1, 0); // 초기 색상 (투명색)
        endColor = Color.white; // 최종 색상 (흰색)
        startPosition = transform.position; // 초기 위치
        endPosition = startPosition + new Vector3(0, moveDistance, 0); // 최종 위치 (위로 2 유닛)   
    }

    private void Update()
    {
        if (gameObject.transform.position.y >= 10)
        {
            Destroy(gameObject);
        }
        if (isMoving)
        {
            Vector2 movement = new Vector2(0, 20);
            rigid2D.AddForce(movement * kunaiSpeed);
        }
    }

    public void ShowKunai()
    {
        StartCoroutine(FadeAndMoveCoroutine());
    }
    IEnumerator FadeAndMoveCoroutine()
    {
        float elapsedTime = 0;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            t = t * t * (3f - 2f * t); // EaseInOut 방식

            // 색상 변경
            spriteRenderer.color = Color.Lerp(startColor, endColor, t);

            // 위치 변경
            transform.position = Vector3.Lerp(startPosition, endPosition, t);

            yield return null;
        }
        EndShowKunai();
    }
    public void EndShowKunai()
    {
        spriteRenderer.color = endColor;
        transform.position = endPosition;
    }
    public void HideKunai()
    {
        spriteRenderer.color = startColor;
        Debug.Log("Knife Hide");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Lock"))
        {
            Destroy(gameObject);
        }
        else
        {
            isUse = true;
        }
    }
}
