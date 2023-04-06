using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeMixer : MonoBehaviour
{
    [SerializeField] private AudioMixer audioMixer;

    [SerializeField] private Slider BgmSlider;
    [SerializeField] private Slider SfxSlider;

    public void SetBgmVolume()
    {
        audioMixer.SetFloat("BGM", Mathf.Log10(BgmSlider.value) * 20);
    }

    public void SetSfxVolume()
    {
        audioMixer.SetFloat("SFX", Mathf.Log10(SfxSlider.value) * 20);
    }
}
