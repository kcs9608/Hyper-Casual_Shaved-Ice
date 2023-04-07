using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlayerOnGoal : StateMachineBehaviour
{
    private Goal _goal;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _goal = animator.GetComponent<Goal>();
        if (_goal != null)
        {
            _goal._isPlayerOnGoal -= () => animator.SetTrigger("PlayerOnGoal");
            _goal._isPlayerOnGoal += () => animator.SetTrigger("PlayerOnGoal");
        }
    }
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_goal != null)
        {
            _goal._isPlayerOnGoal -= () => animator.SetTrigger("PlayerOnGoal");
        }
    }
}

