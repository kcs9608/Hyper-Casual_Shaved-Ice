using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : StateMachineBehaviour
{
    [SerializeField] private GameObject[] _shavedIce;
    private Vector3 _spawnPoint;
    private int _objectIndex;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject player = animator.GetComponent<Goal>()._player;
        _objectIndex = animator.GetComponent<Goal>()._starNum - 1;
        _spawnPoint = player.transform.position;
        player.SetActive(false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject shavedIce = Instantiate(_shavedIce[_objectIndex], _spawnPoint, new Quaternion(0, 90, 0, 0));
        shavedIce.name = "Shaved Ice";
        shavedIce.tag = "Player";
        shavedIce.AddComponent<ShavedIce>();
    }
}
