using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EndingCamera : Camera
{
    private Vector3 _targetPoint = new Vector3(0, 12, 0);
    private float _lerpSpeed = 0.05f;
    private float _elapsedTime;
    private float _targetTime;
    private bool _isOnPoint = false;

    private void OnEnable()
    {
        _targetTime = 6.5f;
    }
    void LateUpdate()
    {
        if (!_isOnPoint)
        {
            transform.position = Vector3.Lerp(transform.position, _targetPoint, _lerpSpeed);
            if(transform.position.y >= _targetPoint.y - 0.1f)
            {
                _isOnPoint = true;
            }
            return;
        }
        
        if(_elapsedTime < _targetTime)
        {
            _elapsedTime += Time.deltaTime;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, _target.transform.position - _offset, _lerpSpeed);
        }
    }
}
