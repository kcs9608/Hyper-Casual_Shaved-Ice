using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class Sound
{
    public string soundName;
    public AudioClip clip;
}

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    [Header("사운드 등록")]
    [SerializeField] Sound[] bgmSounds;
    [SerializeField] Sound[] sfxSounds;

    [Header("Bgm 플레이어")]
    [SerializeField] AudioSource bgmPlayer;
    private GameObject[] musics;

    [Header("Sfx 플레이어")]
    [SerializeField] AudioSource[] sfxPlayer;

    private void Awake()
    {
        musics = GameObject.FindGameObjectsWithTag("Music");

        if (musics.Length >= 2)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(transform.gameObject);
        bgmPlayer = GetComponent<AudioSource>();
    }

    private void Start()
    {
        instance = this;
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

    public void PlaySoundEffect(string soundName)
    {
        for (int i = 0; i < sfxSounds.Length; ++i)
        {
            if (soundName == sfxSounds[i].soundName)
            {
                for (int j = 0; j < sfxPlayer.Length; ++j)
                {
                    if (!sfxPlayer[j].isPlaying)
                    {
                        sfxPlayer[j].clip = sfxSounds[i].clip;
                        sfxPlayer[j].Play();
                        return;
                    }
                }
                Debug.Log("모든 sfxPlayer가 사용중");
                return;
            }
        }
        Debug.Log("등록된 sfxSound가 없음");
    }

    public void PlayBtnClickSound()
    {
        sfxPlayer[0].Play();
        DontDestroyOnLoad(gameObject);
    }

    public void PlayMusic()
    {
        if (bgmPlayer.isPlaying)
        {
            return;
        }
        bgmPlayer.Play();
    }

    public void StopMusic()
    {
        bgmPlayer.Stop();
    }
}
