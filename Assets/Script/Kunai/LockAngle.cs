using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LockAngle : MonoBehaviour
{
    private float distance = 10.0f; // 캐스트 거리
    public Vector2 Angle(float angle)
    {
        // 각도를 라디안으로 변환
        float angleRad = angle * Mathf.Deg2Rad;

        // 각도에 따라 방향 벡터 계산
        Vector2 direction = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));


        // 충돌이 없으면 지정한 각도와 거리로 프리팹 생성
        Vector2 spawnPosition = (Vector2)transform.position + direction * distance;
        Debug.DrawLine(transform.position, spawnPosition, Color.green); // 캐스트 방향과 거리까지의 라인을 그립니다.
        return spawnPosition;
    }
}
