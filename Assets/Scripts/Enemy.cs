using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���� ����� �� Ÿ�� ���ݿ� ���� ���������,
// �� ������ �����Ͽ� ����������� �����ϱ� ���� EnemyDestroyType ������ ����
// ������--> const��� ����ϸ�, ���� ������Ʈ�� ���¸� ����
public enum EnemyDestroyType { Kill = 0, Arrive }

public class Enemy : MonoBehaviour
{
    private int wayPointCount;              // �̵� ��� ����
    private Transform[] wayPoints;          // �̵� ��� ����
    private int currentIndex = 0;           // ���� ��ǥ���� �ε���
    private Movement2D movement2D;          // ������Ʈ �̵� ����
    private EnemySpawner enemySpawner;      // ���� ������ ������ ���� �ʰ� EnemySpawner�� �˷��� ����

    [SerializeField]
    private int point = 10;                 // �� ��� �� ȹ�� ������ ����Ʈ

    public void Setup(EnemySpawner enemySpawner, Transform[] wayPoints)
    {
        movement2D = GetComponent<Movement2D>();
        this.enemySpawner = enemySpawner;

        // �� �̵� ��� wayPoints ���� ����
        wayPointCount = wayPoints.Length;
        this.wayPoints = new Transform[wayPointCount];
        this.wayPoints = wayPoints;

        // ���� ��ġ�� ù��° wayPoint ��ġ�� ����
        transform.position = wayPoints[currentIndex].position;

        // �� �̵�/��ǥ���� ���� �ڷ�ƾ �Լ� ����
        StartCoroutine("OnMove");
    }

    private IEnumerator OnMove()
    {
        // ���� �̵� ���� ����
        NextMoveTo();
        int count = 1;
        while (true)
        {
            //
            if (Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.02f * movement2D.MoveSpeed)
            {
                if (count % 2 == 0)
                {
                    var ani = GetComponent<Animator>();
                    ani.SetTrigger("front");
                }
                else if (count % 3 == 0)
                {
                    var ani = GetComponent<Animator>();
                    ani.SetTrigger("back");
                }
                else if (count % 7 == 0)
                {
                    var ani = GetComponent<Animator>();
                    ani.SetTrigger("back");
                }

                // ���� �̵� ���� ����
                NextMoveTo();
                count++;
                Debug.Log(count);
            }

            yield return null;
        }
    }

    private void NextMoveTo()
    {
        // ���� �̵��� wayPoints�� �����ִٸ�
        if (currentIndex < wayPointCount - 1)
        {
            // ���� ��ġ�� ��Ȯ�ϰ� ��ǥ ��ġ�� ����
            transform.position = wayPoints[currentIndex].position;
            // �̵� ���� ���� => ���� ��ǥ����(wayPoints)
            currentIndex++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            movement2D.MoveTo(direction);
        }
        // ���� ��ġ�� ������ wayPoints�̸�
        else
        {
            // ��ǥ������ �����ؼ� ����� ���� ����Ʈ�� ���� �ʵ���
            point = 0;

            // �� ������Ʈ ����
            //Destroy(gameObject);
            OnDie(EnemyDestroyType.Arrive);
        }
    }

    public void OnDie(EnemyDestroyType type)
    {
        // EnemySpawner���� ����Ʈ�� �� ������ �����ϱ� ������ Destroy()�� �������� �ʰ�
        // EnemySpawner���� ������ ������ �� �ʿ��� ó���� �ϵ��� DestroyEnemy() �Լ� ȣ��
        enemySpawner.DestroyEnemy(type, this, point);
        // this == �� �ڽ� (EnemyComponent)�� �� ��.
    }

}
