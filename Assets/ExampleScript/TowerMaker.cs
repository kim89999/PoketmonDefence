using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerMaker : MonoBehaviour
{
    public GameObject SplashTower = null;
    public GameObject ThunderTower = null;

    //public int[] MakeMap = new int[260];
    // Use this for initialization
    void Start()
    {
        Vector3 basicpos = new Vector3(6.7f, 0.7f, 0);
        Instantiate(SplashTower, basicpos, Quaternion.identity);
        Instantiate(ThunderTower, basicpos + new Vector3(1.0f, 0.0f), Quaternion.identity);

        //MakeMap = GameObject.FindGameObjectWithTag("TileManager").GetComponent<Tile>().map;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
