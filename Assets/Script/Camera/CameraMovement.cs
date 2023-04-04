using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Vector3 _offset;
    private GameObject _target;
    [SerializeField] private GameObject _fridge;
    private Goal _goal;
    private bool _isCleared;
    [SerializeField] private Vector3 _targetPoint = new Vector3(0,8,0);
    [SerializeField][Range(0, 1)] private float _lerpSpeed = 0.01f;
    void Awake()
    {
        _target = GameObject.FindGameObjectWithTag("Player");
        _offset = _target.transform.position - transform.position;
        _goal = _fridge.GetComponent<Goal>();
        _isCleared = false;
        if(_goal != null)
        {
            _goal._isPlayerOnGoal -= () => _isCleared = true;
            _goal._isPlayerOnGoal += () => _isCleared = true;
        }
    }

    void LateUpdate()
    {
        if(!_isCleared)
        {
            transform.position = _target.transform.position - _offset;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, _targetPoint, _lerpSpeed);
        }
    }

    private void OnDestroy()
    {
        if (_goal != null)
        {
            _goal._isPlayerOnGoal -= () => _isCleared = true;
        }
    }
}
