using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FridgeShake : StateMachineBehaviour
{
    [SerializeField] private float _shakeTense = 10f;
    [SerializeField] private float _targetWaitTime = 1f;
    [SerializeField] private float _steamPositionY = 10f;
    [SerializeField] private GameObject _steamParticle;
    [SerializeField] private GameObject _openSteamParticle;
    [SerializeField] private GameObject _shavedIce;
    private float _elapsedTime;
    private float _explosionTime;
    [SerializeField] private float _targetExplosionTime = 0.5f;
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject player = animator.GetComponent<Goal>()._player;
        Vector3 spawnPoint = player.transform.position;
        player.SetActive(false);
        Instantiate(_shavedIce, spawnPoint, new Quaternion(0, 0, 0, 0));
    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (_elapsedTime < _targetWaitTime)
        {
            _elapsedTime += Time.deltaTime;
            _explosionTime += Time.deltaTime;
            animator.transform.rotation = Quaternion.Euler(_shakeTense * (2 * Random.value - 1), 90, _shakeTense * (2 * Random.value - 1));
        }
        else
        {
            animator.transform.rotation = Quaternion.Euler(0, 90, 0);
            animator.SetTrigger("IsExploded");
        }
        if (_explosionTime > _targetExplosionTime)
        {
            Instantiate(_steamParticle, new Vector3(Random.Range(-7,7), Random.Range(3, 15), 25), new Quaternion(0, 0, 0, 0));
            _explosionTime = 0;
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Instantiate(_openSteamParticle, new Vector3(animator.transform.position.x, _steamPositionY, animator.transform.position.z), new Quaternion(0, 0, 0, 0));
    }
}
