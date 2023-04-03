using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgm : MonoBehaviour
{
    private AudioSource bgmPlayer;
    private GameObject[] bgms;

    private void Awake()
    {
        bgms = GameObject.FindGameObjectsWithTag("Bgm");

        if (bgms.Length >= 2)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(transform.gameObject);

        bgmPlayer = GetComponent<AudioSource>();
    }

    private void Start()
    {
        bgmPlayer.Play();
    }
}
