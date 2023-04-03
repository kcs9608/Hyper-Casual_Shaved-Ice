using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sfx : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] sfxPlayer;
    [SerializeField]
    private AudioClip[] sfxClip;

    public AudioSource btnClickSfxSound;

    private enum SfxObj
    {
        GetIce,
        GetFire,
        GetTopping,
        GetSyrup,
        StageClear
    };

    private int sfxCursor;

    private void SfxPlay(SfxObj type)
    {
        switch (type)
        {
            case SfxObj.GetIce:
                sfxPlayer[sfxCursor].clip = sfxClip[0];
                break;

            case SfxObj.GetFire:
                sfxPlayer[sfxCursor].clip = sfxClip[1];
                break;

            case SfxObj.GetTopping:
                sfxPlayer[sfxCursor].clip = sfxClip[2];
                break;

            case SfxObj.GetSyrup:
                sfxPlayer[sfxCursor].clip = sfxClip[3];
                break;

            case SfxObj.StageClear:
                sfxPlayer[sfxCursor].clip = sfxClip[4];
                break;
        }

        sfxPlayer[sfxCursor].Play();
        sfxCursor = (sfxCursor + 1) % sfxPlayer.Length;
    }

    private void BtnClickSound()
    {
        btnClickSfxSound.Play();
    }
}
