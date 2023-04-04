using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerOnGoal : MonoBehaviour
{
    [SerializeField] private GameObject _fridge;
    private Goal _goal;
    void Awake()
    {
        _goal = _fridge.GetComponent<Goal>();
        if (_goal != null)
        {
            _goal._isPlayerOnGoal -= OnGoal;
            _goal._isPlayerOnGoal += OnGoal;
        }
    }

    private void OnDestroy()
    {
        if (_goal != null)
        {
            _goal._isPlayerOnGoal -= OnGoal;
        }
    }
    private void OnGoal()
    {
        gameObject.GetComponent<PlayerInput>().enabled = false;
        gameObject.GetComponent<PlayerMovement>().enabled = false;
        gameObject.GetComponent<Rigidbody>().useGravity = false;
        transform.GetChild(0).gameObject.SetActive(false);
        gameObject.GetComponent<Animator>().SetTrigger("PlayerOnGoal");
    }
}
