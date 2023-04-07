using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    [SerializeField] public Syrup.SyrupType _goalSyrupType;
    [SerializeField] public Topping.ToppingType _goalToppingType;
    [SerializeField] public int _goalMinSize;
    [SerializeField] public int _goalMaxSize;

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
            _isSatisfied[0] = true;
        }
        else
        {
            _isSatisfied[0] = false;
        }
    }
    public void CheckToppings(Topping topping)
    {
        if (topping._toppingType == _goalToppingType)
        {
            _isSatisfied[1] = true;
        }
        else
        {
            _isSatisfied[1] = false;
        }
    }
    public void CheckSize(int size)
    {
        if (size <= _goalMaxSize && size >= _goalMinSize)
        {
            _isSatisfied[2] = true;
        }
        else
        {
            _isSatisfied[2] = false;
        }
    }
}
