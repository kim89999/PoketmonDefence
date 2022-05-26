using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMusic : MonoBehaviour
{
    public GameObject[] GameObjectName;
    public AudioSource AudioSourceMusic;
    public string tag;


    //씬 이동시 배경음이 안끊기고 유지
    void Awake()
    {
        GameObjectName = GameObject.FindGameObjectsWithTag(tag);

        if (GameObjectName.Length >= 2)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(transform.gameObject);
        AudioSourceMusic = GetComponent<AudioSource>();

    }

    public void PlayMusic()
    {
        if (AudioSourceMusic.isPlaying) return;
        AudioSourceMusic.Play();
    }

    public void StopMusic()
    {
        AudioSourceMusic.Stop();
    }

}


