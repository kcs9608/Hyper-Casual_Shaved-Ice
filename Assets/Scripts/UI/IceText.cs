using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IceText : MonoBehaviour
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
        ScriptTxt.text = $"Ice : {_stageManager._goalMinSize} ~ {_stageManager._goalMaxSize}";
    }
}
