using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    public GameObject[] pokemonArray; // ���� ������Ʈ �迭 ����

    [SerializeField]
    private EnemySpawner enemySpawner;  // ���� �ʿ� �����ϴ� �� ����Ʈ ������ ��� ����

    public void SpawnTower(Transform tileTransform)
    {
        Tile tile = tileTransform.GetComponent<Tile>();

        // Ÿ�� �Ǽ� ��� ���� Ȯ��
        // 1. ���� Ÿ���� ��ġ�� �̹� Ÿ���� �Ǽ��Ǿ� ������ Ÿ�� �Ǽ� X
        if(tile.IsBuildTower == true)
        {
            return;
        }

        // Ÿ���� �Ǽ��Ǿ� �������� ����
        tile.IsBuildTower = true;

        // ������ Ÿ���� ��ġ�� Ÿ�� �Ǽ�
        // random�Լ� -> ����Ʈ �� ���� Ÿ�� �Ǽ�
        GameObject clone = Instantiate(pokemonArray[Random.Range(0, 3)], tileTransform.position, Quaternion.identity);

        // Ÿ�� ���⿡ enemySpawner ���� ����
        //clone.GetComponent<TowerWeapon>().SetUp(enemySpawner);
        ////@@@@@@@@@@�� �κ� ����@@@@@@@@@@@@////
    }
}

/*
 * File : TowerSpawner
 * Desc
 *  : Ÿ�� ���� ���� 
 */