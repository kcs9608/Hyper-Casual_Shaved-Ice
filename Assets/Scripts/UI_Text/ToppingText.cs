using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static Topping;

public class ToppingText : MonoBehaviour
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
        ScriptTxt.text = $"Topping : {_stageManager._goalToppingType}";
    }
}
