using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SceneChange : MonoBehaviour, IPointerClickHandler
{
    public string scenename;
    public bool check;

    public void OnPointerClick(PointerEventData data)
    {
        Debug.Log("SceneChange!!");
        SceneManager.LoadScene(scenename);
        check = true;
    }

    public void Change()
    {
        Debug.Log("SceneChange!!");
        SceneManager.LoadScene(scenename);
        check = true;
    }

    void Update()
    {
        
    }
}
