using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [SerializeField] private Syrup.SyrupType _goalSyrupType;
    [SerializeField] private Topping.ToppingType _goalToppingType;
    [SerializeField] private int _goalMinSize;
    [SerializeField] private int _goalMaxSize;

    [SerializeField] private int _conditionCount = 3;
    public bool[] _isSatisfied { get; private set; }

    private void Awake()
    {
        _isSatisfied = new bool[_conditionCount];
    }
    public void CheckSyrup(Syrup syrup)
    {
        if(syrup._syrupType == _goalSyrupType)
        {
            Debug.Log("�÷� ����");
            _isSatisfied[0] = true;
        }
        else
        {
            Debug.Log("�÷� �Ҹ���");
            _isSatisfied[0] = false;
        }
    }
    public void CheckToppings(Topping topping)
    {
        if (topping._toppingType == _goalToppingType)
        {
            Debug.Log("���� ����");
            _isSatisfied[1] = true;
        }
        else
        {
            Debug.Log("���� �Ҹ���");
            _isSatisfied[1] = false;
        }
    }
    public void CheckSize(int size)
    {
        if (size <= _goalMaxSize && size >= _goalMinSize)
        {
            Debug.Log("������ ����");
            _isSatisfied[2] = true;
        }
        else
        {
            Debug.Log("������ �Ҹ���");
            _isSatisfied[2] = false;
        }
    }
}
