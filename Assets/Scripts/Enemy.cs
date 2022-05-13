using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int wayPointCount;
    private Transform[] wayPoints;
    private int currentIndex = 0;
    private EnemyMovement movement2D;

    public void Setup(Transform[] wayPoints)
    {
        movement2D = GetComponent<EnemyMovement>();

        // 적 이동 경로 wayPoints 정보 설정
        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        // 적의 위치를 첫번째 wayPoint 위치로 설정
        transform.position = wayPoints[currentIndex].position;

        // 적 이동/목표지점 설정 코루틴 함수 시작
        StartCoroutine("OnMove");
    }

    private IEnumerator OnMove()
    {
        // 다음 이동 방향 설정
        NextMoveTo();

        while (true)
        {
            //
            //
            //
            if (Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.02f * movement2D.MoveSpeed)
            {
                // 다음 이동 방향 설정
                NextMoveTo();
            }

            yield return null;
        }
    }

    private void NextMoveTo()
    {
        // 아직 이동할 wayPoints가 남아있다면
        if (currentIndex < wayPointCount - 1)
        {
            // 적의 위치를 정확하게 목표 위치로 설정
            transform.position = wayPoints[currentIndex].position;
            // 이동 방향 설정 => 다음 목표지점(wayPoints)
            currentIndex++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            movement2D.MoveTo(direction);
        }
        // 현재 위치가 마지막 wayPoints이면
        else
        {
            // 적 오브젝트 삭제
            Destroy(gameObject);
        }
    }
}
