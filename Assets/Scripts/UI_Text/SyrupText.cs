using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SyrupText : MonoBehaviour
{
    private Text ScriptTxt;
    [SerializeField] private GameObject stageManager;
    private StageManager _stageManager;

    private void Awake()
    {
        ScriptTxt = GetComponent<Text>();
        _stageManager = stageManager.GetComponent<StageManager>();
    }

    private void Start()
    {
        ScriptTxt.text = $"Syrup : {_stageManager._goalSyrupType}";
    }
}
