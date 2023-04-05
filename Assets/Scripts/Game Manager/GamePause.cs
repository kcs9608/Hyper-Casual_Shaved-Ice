using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePause : MonoBehaviour
{
    public GameObject settingUi;

    [SerializeField] private AudioSource btnClickSfx;

    public void OnClickSetting()
    {
        btnClickSfx.Play();
        Time.timeScale = 0f;
        settingUi.SetActive(true);
    }

    public void OnClickReturn()
    {
        btnClickSfx.Play();
        Time.timeScale = 1f;
        settingUi.SetActive(false);
    }
}
