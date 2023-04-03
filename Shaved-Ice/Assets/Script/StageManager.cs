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
            Debug.Log("시럽 만족");
            _isSatisfied[0] = true;
        }
        else
        {
            Debug.Log("시럽 불만족");
            _isSatisfied[0] = false;
        }
    }
    public void CheckToppings(Topping topping)
    {
        if (topping._toppingType == _goalToppingType)
        {
            Debug.Log("토핑 만족");
            _isSatisfied[1] = true;
        }
        else
        {
            Debug.Log("토핑 불만족");
            _isSatisfied[1] = false;
        }
    }
    public void CheckSize(int size)
    {
        if (size <= _goalMaxSize && size >= _goalMinSize)
        {
            Debug.Log("시이즈 만족");
            _isSatisfied[2] = true;
        }
        else
        {
            Debug.Log("사이즈 불만족");
            _isSatisfied[2] = false;
        }
    }
}
