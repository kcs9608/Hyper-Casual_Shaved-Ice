using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowSetActive : MonoBehaviour
{
    private float _elapsedTime;
    private float _targetTime = 1.5f;
    private void Update()
    {
        if(_elapsedTime < _targetTime)
        {
            _elapsedTime += Time.deltaTime;
        }
        else
        {
            gameObject.SetActive(false);
            this.enabled = false;
        }
    }
}
