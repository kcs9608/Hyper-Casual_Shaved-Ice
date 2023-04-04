using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FridgeShake : StateMachineBehaviour
{
    [SerializeField] private float _shakeTense = 10f;
    [SerializeField] private float _targetWaitTime = 1f;
    [SerializeField] private GameObject _steamParticle;
    [SerializeField] private GameObject _steamParticle2;
    private float _elapsedTime;
    private float _explosionTime;
    [SerializeField] private float _targetExplosionTime = 0.5f;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_elapsedTime < _targetWaitTime)
        {
            _elapsedTime += Time.deltaTime;
            _explosionTime += Time.deltaTime;
            animator.transform.rotation = Quaternion.Euler(_shakeTense * Random.value, 90, _shakeTense * Random.value);
            if(_explosionTime > _targetExplosionTime)
            {
                int explosionCase = Random.Range(1,4);
                switch (explosionCase)
                {
                    case 1:
                        Instantiate(_steamParticle, new Vector3(-7, 11, 28), new Quaternion(0, 0, 0, 0));
                        break;
                    case 2:
                        Instantiate(_steamParticle, new Vector3(-7, 5, 28), new Quaternion(0, 0, 0, 0));
                        break;
                    case 3:
                        Instantiate(_steamParticle, new Vector3(7, 15, 28), new Quaternion(0, 0, 0, 0));
                        break;
                    case 4:
                        Instantiate(_steamParticle, new Vector3(7, 9, 28), new Quaternion(0, 0, 0, 0));
                        break;
                    default:
                        break;
                }
                _explosionTime = 0;
            }
        }
        else
        {
            animator.SetTrigger("IsExploded");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Instantiate(_steamParticle2, animator.transform);
    }

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
