using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamEffect : StateMachineBehaviour
{
    [SerializeField] private GameObject _steamParticle;
    [SerializeField] private GameObject _openSteamParticle;

    private float _explosionTime;
    [SerializeField] private float _targetExplosionTime = 0.5f;
    [SerializeField] private float _openSteamParticleY = 10f;
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_explosionTime < _targetExplosionTime)
        {
            _explosionTime += Time.deltaTime;
        }
        else
        {
            Instantiate(_steamParticle, new Vector3(Random.Range(-7, 7), Random.Range(3, 15), animator.transform.position.z - 3), new Quaternion(0, 0, 0, 0));
            _explosionTime = 0;
        }
    }
    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Instantiate(_steamParticle, new Vector3(0, _openSteamParticleY, animator.transform.position.z), new Quaternion(0, 0, 0, 0));
    }
}
