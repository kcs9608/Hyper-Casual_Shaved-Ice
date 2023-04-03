using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Rigidbody _rigid;
    [SerializeField]
    [Range(3f, 15f)]
    private float _speed;
    public bool _isTest;
    private GameObject _floor;
    private float _floorX;
    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _rigid = GetComponent<Rigidbody>();
        _floor = GameObject.FindWithTag("Floor");
        _floorX = _floor.transform.localScale.x * 5;
    }
    void FixedUpdate()
    {
        if(_isTest)
        {
            transform.position += new Vector3(_playerInput._horizontal, 0, _playerInput._vertical) * (_speed * Time.fixedDeltaTime);
        }
        else
        {
            transform.position += new Vector3(_playerInput._horizontal, 0, 1) * (_speed * Time.fixedDeltaTime);
        }
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -_floorX + (transform.localScale.x / 2), _floorX - (transform.localScale.x / 2)), transform.position.y, transform.position.z);
    }
    
}
