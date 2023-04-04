using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CheckPlayerInFridge : StateMachineBehaviour
{
    [SerializeField] private float _targetWaitTime;
    private float _elapsedTime;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _elapsedTime = 0;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_elapsedTime < _targetWaitTime)
        {
            _elapsedTime += Time.deltaTime;
        }
        else
        {
            animator.SetTrigger("PlayerInFridge");
        }
    }
}
