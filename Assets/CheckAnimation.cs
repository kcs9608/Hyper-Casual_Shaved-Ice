using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckAnimation : StateMachineBehaviour
{
    [SerializeField] private float _waitTime;
    private float _elapsedTime;
    private bool _isSoundPlayed;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _isSoundPlayed = false;
    }
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(_elapsedTime < _waitTime)
        {
            _elapsedTime += Time.deltaTime;
        }
        else
        {
            if (!_isSoundPlayed)
            {
                animator.GetComponent<Goal>().stageClearSfx.Play();
                _isSoundPlayed = true;
            }
            animator.GetComponent<Goal>().LoadStageClearUI();
        }
    }
}
