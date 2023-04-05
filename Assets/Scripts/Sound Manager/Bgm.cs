using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bgm : MonoBehaviour
{
    [System.Serializable]
    private class Sound
    {
        public string soundName;
        public AudioClip clip;
    }

    [Header("���� ���")]
    [SerializeField] Sound[] bgmSounds;

    [Header("Bgm �÷��̾�")]
    [SerializeField] private AudioSource bgmPlayer;

    private void Awake()
    {
        var bgms = FindObjectsOfType<Bgm>();
        if (bgms.Length == 1)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayRandomBgm();
    }

    private void PlayRandomBgm()
    {
        if (bgmSounds.Length == 0)
        {
            return;
        }

        int random = Random.Range(0, bgmSounds.Length);
        bgmPlayer.clip = bgmSounds[random].clip;
        bgmPlayer.Play();
    }
}
