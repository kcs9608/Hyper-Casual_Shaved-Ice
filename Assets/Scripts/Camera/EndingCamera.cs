using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EndingCamera : Camera
{
    private Vector3 _targetPoint = new Vector3(0, 12, 170);
    private float _lerpSpeed = 30f;
    private float _moveTime;
    private float _elapsedTime;
    private float _targetTime;
    private bool _isOnPoint = false;

    private void OnEnable()
    {
        float distance = Vector3.Distance(transform.position, _targetPoint);
        _targetTime = 6.5f;
        _moveTime = distance / _lerpSpeed;
    }
    void LateUpdate()
    {
        if (!_isOnPoint)
        {
            float ratio = Mathf.Clamp01(Time.deltaTime / _moveTime);
            transform.position = Vector3.Lerp(transform.position, _targetPoint, ratio);
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
            float ratio = Mathf.Clamp01(Time.deltaTime / _moveTime);
            transform.position = Vector3.Lerp(transform.position, _target.transform.position - _offset, ratio);
        }
    }
}
