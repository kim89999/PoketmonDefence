using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    public Vector3 targetPosition = Vector3.zero;
    public GameObject ExplosionParticle = null;
    // Use this for initialization
    void Start()
    {

    }
    // ���� �׷����Ѱ�
    // Update is called once per frame
    void Update()
    {
        transform.Translate(targetPosition * Time.deltaTime * 3.0f);

        // ���� �θ��� ���̰� �����Ÿ�(1.5f) �����ϸ� ����
        float distance = Vector3.Distance(transform.position, transform.parent.position);
        if (distance > 1.5f)
        {
            Destroy(gameObject);
        }

        if (transform.position.x < -0.64f || transform.position.x > 13.44f || transform.position.y < -0.64f || transform.position.y > 8.32f)
        {
            Destroy(gameObject);
        }
    }
}
