using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using static UnityEngine.GraphicsBuffer;

public class PlayerMelt : StateMachineBehaviour
{
    [SerializeField] private float _slideDist;
    [SerializeField] private float _slideSpeed;
    private float _pointX;
    private float _pointZ;
    private float _moveTime;
    private Vector3 _targetPoint;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _pointX = animator.transform.position.x;
        _pointZ = animator.transform.position.z;
        _targetPoint = new Vector3(_pointX, 0, _pointZ + _slideDist);
        float distance = Vector3.Distance(animator.transform.position, _targetPoint);
        _moveTime = distance / _slideSpeed;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(animator.transform.localScale.x >= 0 )
        {
            animator.transform.localScale = new Vector3(animator.transform.localScale.x - Time.deltaTime, animator.transform.localScale.y - Time.deltaTime, animator.transform.localScale.z - Time.deltaTime);
        }
        float ratio = Mathf.Clamp01(Time.deltaTime / _moveTime);
        animator.transform.position = Vector3.Lerp(animator.transform.position, _targetPoint, ratio);
        if(Vector3.Distance(animator.transform.position, _targetPoint) <= 0.2f)
        {
            animator.GetComponent<PlayerGameOver>().LoadGameOverUI();
        }
    }
}
