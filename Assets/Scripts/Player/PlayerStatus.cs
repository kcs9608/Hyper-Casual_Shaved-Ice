using System;
using ItemInterface;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public event Action StatusChanged;
    public Syrup _currentSyrup { get; private set; }
    public Topping _currentTopping { get; private set; }
    public int _currentServings { get; private set; }
    private void OnEnable()
    {
        _currentServings = 1;
        GameObject defaultTopping = new();
        defaultTopping.name = "Default Topping";
        defaultTopping.transform.SetParent(transform);
        defaultTopping.AddComponent<Topping>()._toppingType = Topping.ToppingType.None;
        _currentTopping = defaultTopping.GetComponent<Topping>();

        for (int i = 1; i < transform.childCount; ++i)
        {
            transform.GetChild(i).gameObject.SetActive(false);
        }
    }

    public void ChangeItem(Syrup changedItem) =>  _currentSyrup = changedItem;
    public void ChangeItem(Topping changedItem) => _currentTopping = changedItem;
    public void ChangeSize(int serving)
    {
        _currentServings = serving;
        UpdateSize();
    }
    public void UpdateSize() => StatusChanged?.Invoke();
}
