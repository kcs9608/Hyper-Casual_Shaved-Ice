using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 _offset;
    private GameObject _target;
    void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        _offset = _target.transform.position - transform.position;
    }

    void LateUpdate()
    {
        transform.position = _target.transform.position - _offset;
    }
}
