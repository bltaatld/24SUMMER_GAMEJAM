using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockBehaviour : MonoBehaviour
{
    [Header("GameObject")]
    [SerializeField] private GameObject LockHolder;
    [SerializeField] private GameObject LockPrefab;

    [Header("List")]
    [SerializeField] List<GameObject> LockObjectList;
    [SerializeField] List<Lock> LockList;


    [Header("Other")]
    public int numberOfLocks = 1;

    public float radius = 0.5f; // ���� ������
    public Vector2 direction = Vector2.right; // ĳ��Ʈ ����
    public float distance = 10.0f; // ĳ��Ʈ �Ÿ�
    public LayerMask layerMask; // �浹�� ������ ���̾� ����ũ
    private void Start()
    {
        for (int i = 0; i < numberOfLocks; i++)
        {
            GameObject lockObject = Instantiate(LockPrefab, Vector2.zero, Quaternion.identity, LockHolder.transform);
            LockObjectList.Add(lockObject);
            Debug.Log("Object Add");
        }
        foreach (Lock lockObject in LockPrefab.GetComponentsInChildren<Lock>())
        {
            LockList.Add(lockObject);
            Debug.Log("LockList Add");
        }
    }
    void Update()
    {
        CircleCast();
    }

    void CircleCast()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, radius, direction, distance, layerMask);

        if (hit.collider != null)
        {
            Debug.Log("Hit " + hit.collider.name);
            Debug.DrawLine(transform.position, hit.point, Color.red); // ��Ʈ ���������� ������ �׸��ϴ�.

            // ��Ʈ ������ ������ ����
            Instantiate(LockPrefab, hit.point, Quaternion.identity);
        }
        else
        {
            Debug.DrawLine(transform.position, transform.position + (Vector3)direction * distance, Color.green); // ĳ��Ʈ ����� �Ÿ������� ������ �׸��ϴ�.
        }
    }
}
