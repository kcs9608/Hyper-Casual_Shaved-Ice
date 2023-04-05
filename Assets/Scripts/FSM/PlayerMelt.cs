using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerMelt : StateMachineBehaviour
{
    [SerializeField] private float _slideDist;
    [SerializeField][Range(0, 1)] private float _slideSpeed;
    private float _pointX;
    private float _pointZ;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        _pointX = animator.transform.position.x;
        _pointZ = animator.transform.position.z;
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(animator.transform.localScale.x >= 0 )
        {
            animator.transform.localScale = new Vector3(animator.transform.localScale.x - Time.deltaTime, animator.transform.localScale.y - Time.deltaTime, animator.transform.localScale.z - Time.deltaTime);
        }
        animator.transform.position = Vector3.Lerp(animator.transform.position, new Vector3(_pointX, 0, _pointZ + _slideDist), _slideSpeed);
    }
}
