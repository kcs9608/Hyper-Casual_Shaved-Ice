using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShavedIce : MonoBehaviour
{
    private float _rotateSpeed = 2f;
    void FixedUpdate()  
    {
        transform.Rotate(Vector3.up * _rotateSpeed);
    }
}
