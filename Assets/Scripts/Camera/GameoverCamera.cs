using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class GameoverCamera : Camera
{
    private float _zoomOutScale = 1.5f;
    private float _lerpSpeed = 30f;
    private float _moveTime;
    private Vector3 _endPoint;
    private void OnEnable()
    {
        _endPoint = _target.transform.position - (_offset * _zoomOutScale);
        float distance = Vector3.Distance(transform.position, _endPoint);
        _moveTime = distance / _lerpSpeed;
    }
    void LateUpdate()
    {
        float ratio = Mathf.Clamp01(Time.deltaTime / _moveTime);
        transform.position = Vector3.Lerp(transform.position, _endPoint, ratio);
    }
}
