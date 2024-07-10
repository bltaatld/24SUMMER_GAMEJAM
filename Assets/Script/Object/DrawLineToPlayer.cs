using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineToPlayer : MonoBehaviour
{
    public GameObject player; // �÷��̾� GameObject
    public GameObject linePrefab; // ���� ������
    public GameObject lineObject; // ������ ���� ������
    public Transform startTransform; // ������ Ʈ������
    public Transform endTransform; // ���� Ʈ������
    private LineRenderer lineRenderer; // ���� ������ ������Ʈ

    void Start()
    {
        // ���� �������� �ν��Ͻ�ȭ�մϴ�.
        lineObject = Instantiate(linePrefab);
        lineRenderer = lineObject.GetComponent<LineRenderer>();

        player = GameObject.Find("PlayerBasics");

        if (player != null)
        {
            // �÷��̾� ������Ʈ�� �ڽ� ������Ʈ���� ã���ϴ�.
            endTransform = player.transform.Find("Player");

            if (endTransform == null)
            {
                Debug.LogWarning("Child object with the specified name not found.");
            }
        }


        if (lineRenderer == null)
        {
            Debug.LogError("LineRenderer component not found in the prefab.");
            return;
        }

        // ������ �������� ������ �����մϴ�.
        if (startTransform != null && endTransform != null)
        {
            lineRenderer.SetPosition(0, startTransform.position); // ������
            lineRenderer.SetPosition(1, endTransform.position); // ����
        }
        else
        {
            Debug.LogWarning("Start or end transform is not assigned.");
        }
    }

    void Update()
    {
        // ���÷� �� Ʈ�������� ��ġ�� �� �����Ӹ��� ������Ʈ�մϴ�.
        // �����δ� �ʿ信 ���� ��ġ�� ����� �� ������Ʈ�ϴ� ������ �����ؾ� �մϴ�.
        if (startTransform != null && endTransform != null)
        {
            lineRenderer.SetPosition(0, startTransform.position); // ������
            lineRenderer.SetPosition(1, endTransform.position); // ����
        }
    }
}
