using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FridgeShake : StateMachineBehaviour
{
    [SerializeField] private float _shakeTense = 10f;
    [SerializeField] private float _targetWaitTime = 1f;
    private float _elapsedTime;
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_elapsedTime < _targetWaitTime)
        {
            _elapsedTime += Time.deltaTime;
            animator.transform.rotation = Quaternion.Euler(_shakeTense * (2 * Random.value - 1), 90, _shakeTense * (2 * Random.value - 1));
            return;
        }
        else
        {
            animator.transform.rotation = Quaternion.Euler(0, 90, 0);
            animator.SetTrigger("IsExploded");
        }
    }
}
