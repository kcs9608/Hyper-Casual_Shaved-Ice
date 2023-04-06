using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Operator;
using UnityEngine.UIElements;

public class OperatorPanelText : MonoBehaviour
{
    private Operator _operator;

    private void Awake()
    {
        _operator = GetComponent<Operator>();
    }

    [SerializeField]
    private int _weight;

    void OperatorText()
    {
        float text = 1f;

        switch (_operator.GetOperatorType())
        {
            case OperatorType.Add:
                text = (100 + _weight) / 100f;
                break;
            case OperatorType.Subtract:
                text = (100 - _weight) / 100f;
                break;
            case OperatorType.Multiply:
                text = (100 + (_weight * 10)) / 100f;
                break;
            case OperatorType.Divide:
                text = (100 - (_weight * 10)) / 100f;
                break;
            default:
                Debug.Log("잘못된 OperatorType 입력이 있습니다.");
                break;
        }
    }
}