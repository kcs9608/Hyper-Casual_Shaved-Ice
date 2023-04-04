using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpToFridge : StateMachineBehaviour
{
    [SerializeField] private Vector3 _targetPosition;
    [SerializeField][Range(0, 1)] private float _lerpSpeed = 0.005f;
    [SerializeField] private float _targetWaitTime;
    private float _elapsedTime;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _elapsedTime = 0;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(_elapsedTime < _targetWaitTime)
        {
            _elapsedTime += Time.deltaTime;
        }
        else
        {
            animator.transform.position = Vector3.Lerp(animator.transform.position, _targetPosition, _lerpSpeed);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
