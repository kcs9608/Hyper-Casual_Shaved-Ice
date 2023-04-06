using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMainScreen : MonoBehaviour
{
    [SerializeField] GameObject _inGameCanvas;
    public void Awake()
    {
        Time.timeScale = 0;
    }
    public void OnTouch()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
        _inGameCanvas.SetActive(true);
    }
}
