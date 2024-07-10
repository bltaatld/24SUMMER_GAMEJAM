using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineToPlayer : MonoBehaviour
{
    public GameObject player; // 플레이어 GameObject
    public GameObject linePrefab; // 라인 프리팹
    public GameObject lineObject; // 생성된 라인 프리팹
    public Transform startTransform; // 시작점 트랜스폼
    public Transform endTransform; // 끝점 트랜스폼
    private LineRenderer lineRenderer; // 라인 렌더러 컴포넌트

    void Start()
    {
        // 라인 프리팹을 인스턴스화합니다.
        lineObject = Instantiate(linePrefab);
        lineRenderer = lineObject.GetComponent<LineRenderer>();

        player = GameObject.Find("PlayerBasics");

        if (player != null)
        {
            // 플레이어 오브젝트의 자식 오브젝트들을 찾습니다.
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

        // 라인의 시작점과 끝점을 설정합니다.
        if (startTransform != null && endTransform != null)
        {
            lineRenderer.SetPosition(0, startTransform.position); // 시작점
            lineRenderer.SetPosition(1, endTransform.position); // 끝점
        }
        else
        {
            Debug.LogWarning("Start or end transform is not assigned.");
        }
    }

    void Update()
    {
        // 예시로 두 트랜스폼의 위치를 매 프레임마다 업데이트합니다.
        // 실제로는 필요에 따라 위치가 변경될 때 업데이트하는 로직을 구현해야 합니다.
        if (startTransform != null && endTransform != null)
        {
            lineRenderer.SetPosition(0, startTransform.position); // 시작점
            lineRenderer.SetPosition(1, endTransform.position); // 끝점
        }
    }
}
