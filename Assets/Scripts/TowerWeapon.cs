using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponState { SearchTarget = 0, AttackToTarget }     // 대상을 찾고, 공격

public class TowerWeapon : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;                          // 발사체 프리팹

    [SerializeField]
    private Transform spawnPoint;                                 // 발사체 생성 위치

    [SerializeField]
    private float attackRate = 1f;                              // 공격 속도

    [SerializeField]
    private float attackRange = 3.0f;                             // 공격 범위

    [SerializeField]
    private int attackDamage = 1;                                 // 공격력

    private WeaponState weaponState = WeaponState.SearchTarget;    // 타워 무기의 상태
    private Transform attackTarget = null;                        // 공격 대상
    private EnemySpawner enemySpawner;                            // 게임에 존재하는 적 정보 획득용


    public void Setup(EnemySpawner enemySpawner)
    {
        this.enemySpawner = enemySpawner;

        // 최소 상태를 WeaponState.SearchTarget으로 설정
        ChangeState(WeaponState.SearchTarget);
    }

    public void ChangeState(WeaponState newState)
    {
        // 이전에 재생중이던 상태 종료
        StopCoroutine(weaponState.ToString());

        // 상태 변경
        weaponState = newState;

        // 새로운 상태 재생
        StartCoroutine(weaponState.ToString());
    }

    private void Update()
    {
        if (attackTarget != null)
        {
            //RotateToTarget(); // 타켓이 null이 아니면 타켓을 바라보도록
        }
    }

    // 타워가 적을 바라보도록 하는 함수
    private void RotateToTarget()
    {
        // 원점으로부터의 거리와 수평축으로부터의 각도를 이용해 위치를 구하는 극 좌표계 이용
        // 각도 = arctan(x/y)
        // x,y 변위값 구하기
        float dx = attackTarget.position.x - transform.position.x;
        float dy = attackTarget.position.y - transform.position.y;

        // x,y 변위값을 바탕으로 각도 구하기
        // 각도가 radian 단위이기 때문에 Mathf.Rad2Deg를 곱해 도 단위를 구함
        // Mathf.Rad2Deg --> radian에서 degree로 변환 승수
        float degree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        // 인수로 들어온 x와 y의 값으로 아크 탄젠트 함수를 이용해 연산해서 결과값을 라디안 값으로 반환하는 메소드
        transform.rotation = Quaternion.Euler(0, 0, degree);
    }

    private IEnumerator SearchTarget()
    {
        while (true)
        {
            // 제일 가까이 있는 적을 찾기 위해 최소 거리를 최대한 크게 설정
            float closestDistSqr = Mathf.Infinity;
            // EnemySpawner의 EnemyList에 있는 현재 맵에 존재하는 모든 적 검사
            for (int i = 0; i < enemySpawner.EnemyList.Count; ++i) 
            {
                float distance = Vector3.Distance(enemySpawner.EnemyList[i].transform.position, transform.position);

                // 현재 검사중인 적과의 거리가 공격범위 내에 있고, 현재까지 검사한 적보다 거리가 가까우면
                if (distance <= attackRange && distance <= closestDistSqr)
                {
                    closestDistSqr = distance;
                    attackTarget = enemySpawner.EnemyList[i].transform;
                }
            }

            if (attackTarget != null)
            {
                ChangeState(WeaponState.AttackToTarget);
            }
            yield return null;
        }
    }

    private IEnumerator AttackToTarget()
    {
        while (true)
        {
            // 1. target이 있는지 검사 (다른 발사체에 의해 제거, Goal 지점까지 이동해 삭제 등
            if (attackTarget == null)
            {
                ChangeState(WeaponState.SearchTarget);
                break;
            }

            // 2. target이 공격 범위 안에 있는지 검사 (공격 범위를 벗어나면 새로운 적 탐색)
            float distance = Vector3.Distance(attackTarget.position, transform.position);
            if (distance > attackRange)
            {
                attackTarget = null;
                ChangeState(WeaponState.SearchTarget);
                break;
            }

            // 3. attackRate 시간만큼 대기
            yield return new WaitForSeconds(attackRate);

            // 4. 공격 (발사체 생성)
            SpawnProjectile();
        }
    }

    private void SpawnProjectile()
    {
        GameObject clone = Instantiate(projectilePrefab, spawnPoint.position, Quaternion.identity);

        // 생성한 발사체에게 공격대상(attackTarget), 공격력(attackDamage) 정보 제공
        clone.GetComponent<Projectile>().Setup(attackTarget, attackDamage);
    }


}

/*
 * File : TowerWeapon.cs
 * Desc
 *      : 적을 공격하는 타워 무기
 *      : 타워의 공격 대상 설정 및 발사체 생성
 *      
 * Functions
 *  : ChangeState() - 코루틴을 이용한 FSM에서 상태 변경 함수
 *  : RotateToTarget - target 방향으로 전환
 *  : SearchTarget() - 현재 타워에 가장 근접한 적 탐색
 */
