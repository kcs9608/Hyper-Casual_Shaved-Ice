using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyText : MonoBehaviour
{
    private Text ScriptTxt;

    private void Awake()
    {
        ScriptTxt = GetComponent<Text>();
    }

    private void Start()
    {
        ScriptTxt.text = $"Stage {GameManager.Instance._gold}";
    }
}
