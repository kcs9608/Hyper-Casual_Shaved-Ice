using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class GameoverCamera : Camera
{
    private float _zoomOutScale = 1.5f;
    private float _zoomOutSpeed = 0.01f;
    private Vector3 _endPoint;
    private void OnEnable()
    {
        _endPoint = _target.transform.position - (_offset * _zoomOutScale);
    }
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, _endPoint, _zoomOutSpeed);
    }
}
