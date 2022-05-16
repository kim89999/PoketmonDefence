using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject[] pokemonArray; // 게임 오브젝트 배열 선언

    [SerializeField]
    private EnemySpawner enemySpawner;  // 현재 맵에 존재하는 적 리스트 정보를 얻기 위함

    public void SpawnTower(Transform tileTransform)
    {
        Tile tile = tileTransform.GetComponent<Tile>();

        // 타워 건설 기능 여부 확인
        // 1. 현재 타일의 위치에 이미 타워가 건설되어 있으면 타워 건설 X
        if(tile.IsBuildTower == true)
        {
            return;
        }

        // 타워가 건설되어 있음으로 설정
        tile.IsBuildTower = true;

        // 선택한 타일의 위치에 타워 건설
        // random함수 -> 리스트 내 랜덤 타워 건설
        GameObject clone = Instantiate(pokemonArray[Random.Range(0, 3)], tileTransform.position, Quaternion.identity);

        // 타워 무기에 enemySpawner 정보 전달
        //clone.GetComponent<TowerWeapon>().SetUp(enemySpawner);
        ////@@@@@@@@@@이 부분 오류@@@@@@@@@@@@////
    }
}

/*
 * File : TowerSpawner
 * Desc
 *  : 타워 생성 제어 
 */