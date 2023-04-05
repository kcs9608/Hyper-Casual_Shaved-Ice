using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerInput _playerInput;
    [SerializeField] private float _playerOffset = 6f;
    [SerializeField] private float _floorOffset = 5f;
    [SerializeField]
    [Range(3f, 15f)]
    private float _speed = 8f;
    public bool _isTest;
    private GameObject _floor;
    private float _floorX;
    
    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _floor = GameObject.FindWithTag("Floor");
        _floorX = _floor.transform.localScale.x * _floorOffset;
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
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -_floorX + (transform.localScale.x / _playerOffset), _floorX - (transform.localScale.x / _playerOffset)), 
            transform.position.y, 
            transform.position.z);
    }
    
}
