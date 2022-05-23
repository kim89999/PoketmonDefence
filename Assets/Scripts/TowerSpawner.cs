using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pokemonArray;          // ���� ������Ʈ �迭 ����

    [SerializeField]
    private int towerBuildPoint = 30;           // Ÿ�� �Ǽ��� ���Ǵ� ����Ʈ

    [SerializeField]
    private PlayerPoint playerPoint;            // Ÿ�� �Ǽ� �� ����Ʈ ����

    [SerializeField]
    private EnemySpawner enemySpawner;          // ���� �ʿ� �����ϴ� �� ����Ʈ ������ ��� ����

    public void SpawnTower(Transform tileTransform)
    {
        Tile tile = tileTransform.GetComponent<Tile>();

        // Ÿ�� �Ǽ� ��� ���� Ȯ��
        // 1. Ÿ���� �Ǽ��� ��ŭ ����Ʈ�� ������ Ÿ�� �Ǽ� x
        if ( towerBuildPoint > playerPoint.CurrentPoint )
        {
            return;
        }

        // 2. ���� Ÿ���� ��ġ�� �̹� Ÿ���� �Ǽ��Ǿ� ������ Ÿ�� �Ǽ� X
        if ( tile.IsBuildTower == true)
        {
            return;
        }

        // Ÿ���� �Ǽ��Ǿ� �������� ����
        tile.IsBuildTower = true;

        // Ÿ�� �Ǽ��� �ʿ��� ����Ʈ��ŭ ����
        playerPoint.CurrentPoint -= towerBuildPoint;

        // ������ Ÿ���� ��ġ�� Ÿ�� �Ǽ�
        // random�Լ� -> ����Ʈ �� ���� Ÿ�� �Ǽ�
        GameObject clone = Instantiate(pokemonArray[Random.Range(0, 2)], tileTransform.position, Quaternion.identity);

        // Ÿ�� ���⿡ enemySpawner ���� ����
        clone.GetComponent<TowerWeapon>().Setup(enemySpawner);
    }
}

/*
 * File : TowerSpawner
 * Desc
 *  : Ÿ�� ���� ���� 
 */