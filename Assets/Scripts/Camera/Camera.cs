using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Camera : MonoBehaviour
{
    protected GameObject _target;
    protected Vector3 _offset;
    void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        _offset = _target.transform.position - transform.position;
    }
}
