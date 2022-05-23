using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pokemonArray;          // 게임 오브젝트 배열 선언

    [SerializeField]
    private int towerBuildPoint = 30;           // 타워 건설에 사용되는 포인트

    [SerializeField]
    private PlayerPoint playerPoint;            // 타워 건설 시 포인트 감소

    [SerializeField]
    private EnemySpawner enemySpawner;          // 현재 맵에 존재하는 적 리스트 정보를 얻기 위함

    public void SpawnTower(Transform tileTransform)
    {
        Tile tile = tileTransform.GetComponent<Tile>();

        // 타워 건설 기능 여부 확인
        // 1. 타워를 건설할 만큼 포인트가 없으면 타워 건설 x
        if ( towerBuildPoint > playerPoint.CurrentPoint )
        {
            return;
        }

        // 2. 현재 타일의 위치에 이미 타워가 건설되어 있으면 타워 건설 X
        if ( tile.IsBuildTower == true)
        {
            return;
        }

        // 타워가 건설되어 있음으로 설정
        tile.IsBuildTower = true;

        // 타워 건설에 필요한 포인트만큼 감소
        playerPoint.CurrentPoint -= towerBuildPoint;

        // 선택한 타일의 위치에 타워 건설
        // random함수 -> 리스트 내 랜덤 타워 건설
        GameObject clone = Instantiate(pokemonArray[Random.Range(0, 2)], tileTransform.position, Quaternion.identity);

        // 타워 무기에 enemySpawner 정보 전달
        clone.GetComponent<TowerWeapon>().Setup(enemySpawner);
    }
}

/*
 * File : TowerSpawner
 * Desc
 *  : 타워 생성 제어 
 */