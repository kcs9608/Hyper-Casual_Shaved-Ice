using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class JumpToFridge : StateMachineBehaviour
{
    [SerializeField] private Vector3 _targetPosition = new Vector3(0 , 10, 28);
    [SerializeField] private float _lerpSpeed = 30f;
    private float _moveTime;
    [SerializeField] private float _targetWaitTime = 2f;
    private float _elapsedTime;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _elapsedTime = 0;
        float distance = Vector3.Distance(animator.transform.position, _targetPosition);
        _moveTime = distance / _lerpSpeed;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(_elapsedTime < _targetWaitTime)
        {
            _elapsedTime += Time.deltaTime;
        }
        else
        {
            float ratio = Mathf.Clamp01(Time.deltaTime / _moveTime);
            animator.transform.position = Vector3.Lerp(animator.transform.position, _targetPosition, ratio);
        }
    }
}
