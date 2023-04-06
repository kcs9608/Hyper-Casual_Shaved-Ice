using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : Camera
{
    [SerializeField] private GameObject _fridge;
    private PlayerStatus _status;
    private Goal _goal;
    private bool _isCleared;
    void OnEnable()
    {
        _goal = _fridge.GetComponent<Goal>();
        _status = _target.GetComponent<PlayerStatus>();

        _isCleared = false;

        if (_goal != null)
        {
            _goal._isPlayerOnGoal -= () => _isCleared = true;
            _goal._isPlayerOnGoal += () => _isCleared = true;
        }
        if(_status != null)
        {
            _status.GameOver -= ChangeToGameOverCamera;
            _status.GameOver += ChangeToGameOverCamera;
        }
    }
    void LateUpdate()
    {
        if (!_isCleared)
        {
            transform.position = _target.transform.position - _offset;
            return;
        }
        else
        {
            this.enabled = false;
            gameObject.AddComponent<EndingCamera>();
        }
    }

    private void OnDestroy()
    {
        if (_goal != null)
        {
            _goal._isPlayerOnGoal -= () => _isCleared = true;
        }
        if (_status != null)
        {
            _status.GameOver -= ChangeToGameOverCamera;
        }

    }
    private void ChangeToGameOverCamera()
    {
        this.enabled = false;
        gameObject.AddComponent<GameoverCamera>();
    }
}
