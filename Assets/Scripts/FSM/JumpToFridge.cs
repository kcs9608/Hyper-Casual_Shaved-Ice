using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class JumpToFridge : StateMachineBehaviour
{
    [SerializeField] private Vector3 _targetPosition = new Vector3(0 , 10, 28);
    [SerializeField][Range(0, 1)] private float _lerpSpeed = 0.01f;
    [SerializeField] private float _targetWaitTime = 2f;
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
}
