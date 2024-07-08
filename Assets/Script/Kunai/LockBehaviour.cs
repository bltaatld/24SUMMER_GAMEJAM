using System.Collections.Generic;
using UnityEngine;

public class LockBehaviour : MonoBehaviour
{
    public static LockBehaviour lockBehaviour;

    private void Awake()
    {
        lockBehaviour = this;
    }

    [Header("UI Object")]
    [SerializeField] private int failCount = 3;

    [Header("GameObject")]
    [SerializeField] private GameObject lockHolder;
    [SerializeField] private GameObject lockPrefab;

    [Header("List and Array")]
    public List<GameObject> lockObjectList = new List<GameObject>();
    public List<GameObject> orbitingObjects = new List<GameObject>();

    [Header("Other")]
    [HideInInspector] public int numberOfLocks = 6;

    private float orbitRadius = 2.0f; // 원의 반지름
    public float orbitSpeed = 30.0f; // 공전 속도 (각속도, 단위: degree/second)
    private float[] angles; // 각도를 저장할 배열

    private void Start()
    {
        InitializeLocks();
    }

    private void InitializeLocks()
    {
        angles = new float[numberOfLocks];

        for (int i = 0; i < numberOfLocks; i++)
        {
            GameObject lockObject = Instantiate(lockPrefab, Vector2.zero, Quaternion.identity, lockHolder.transform);
            lockObjectList.Add(lockObject);
            orbitingObjects.Add(lockObject);
            angles[i] = i * (360f / numberOfLocks); // 초기 각도를 균등하게 분배
            lockObject.transform.position = CalculatePosition(angles[i]);

            Debug.Log("Object Added");
        }
    }

    private Vector2 CalculatePosition(float angle)
    {
        // 각도를 라디안으로 변환
        float angleRad = angle * Mathf.Deg2Rad;

        // 각도에 따라 방향 벡터 계산
        Vector2 direction = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));

        // 지정한 각도와 거리로 계산된 위치 반환
        Vector2 spawnPosition = (Vector2)transform.position + direction * orbitRadius;
        Debug.DrawLine(transform.position, spawnPosition, Color.green); // 캐스트 방향과 거리까지의 라인을 그립니다.
        return spawnPosition;
    }

    private void Update()
    {
        OrbitAroundCenter();

        if(numberOfLocks <= 0)
        {
            Debug.Log("GameClear"); //Success Game Clear
        }
    }

    private void OrbitAroundCenter()
    {
        lockHolder.transform.Rotate(new Vector3(0, 0, orbitSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Kunai"))
        {
            if (failCount != 0)
            {
                failCount--;
            }
            else
            {
                Debug.Log("GameOver"); //Hostage Health 0
            }
            Destroy(collision.gameObject);
        }
    }
}
