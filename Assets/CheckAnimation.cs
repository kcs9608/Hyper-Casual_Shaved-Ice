using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnimation : StateMachineBehaviour
{
    [SerializeField] private float _waitTime;
    private float _elapsedTime;

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(_elapsedTime < _waitTime)
        {
            _elapsedTime += Time.deltaTime;
        }
        else
        {
            animator.GetComponent<Goal>().LoadStageClearUI();
        }
    }
}
