using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMakeClick : MonoBehaviour
{
    private bool isclicked = false;

    public GameObject alpha150 = null;
    private GameObject createalpha = null;
    public GameObject realTower = null;

    // Use this for initialization
    void Start()
    {
        isclicked = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        isclicked = true;
        createalpha = Instantiate(alpha150, transform);
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos.z = 1.0f;
        createalpha.transform.position = mousepos;
    }

    private void OnMouseDrag()
    {
        if (isclicked == true)
        {
            // 마우스따라 반투명 캐릭터가 움직임
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousepos.z = 1.0f;
            createalpha.transform.position = mousepos;
        }
    }

    private void OnMouseUp()
    {
        isclicked = false;
        Instantiate(realTower, createalpha.transform.position, Quaternion.identity);
        Destroy(createalpha);
    }
}
