using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using ItemInterface;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Operator : Items
{
    [SerializeField] private AudioSource iceSfx;
    [SerializeField] private AudioSource fireSfx;
    [SerializeField] private float _minSize = 1f;
    [SerializeField] private float _maxSize = 4f;

    public TextMesh _textMesh;

    enum OperatorType
    {
        [InspectorName("Add")] Add,
        [InspectorName("Subtract")] Subtract,
        [InspectorName("Multiply")] Multiply,
        [InspectorName("Divide")] Divide
    }

    [SerializeField]
    OperatorType operatorType;

    [SerializeField]
    private int _weight;

    private void Start()
    {
        switch (operatorType)
        {
            case OperatorType.Add:
                _textMesh.text = $"+ {_weight.ToString()}";
                break;
            case OperatorType.Subtract:
                _textMesh.text = $"- {_weight.ToString()}";
                break;
            case OperatorType.Multiply:
                _textMesh.text = $"x {_weight.ToString()}";
                break;
            case OperatorType.Divide:
                _textMesh.text = $"÷ {_weight.ToString()}";
                break;
            default:
                Debug.Log("잘못된 OperatorType 입력이 있습니다.");
                break;
        }
    }

    public override void EffectToPlayer()
    {
        Transform _playerTransform = _player.GetComponent<Transform>();
        int currentServings = _playerStatus._currentServings;
        float scale = 1f;

        switch (operatorType)
        {
            case OperatorType.Add:
                iceSfx.Play();
                scale = (100 + _weight) / 100f;
                currentServings += _weight;
                
                break;
            case OperatorType.Subtract:
                fireSfx.Play();
                scale = (100 - _weight) / 100f;
                currentServings -= _weight;
                
                break;
            case OperatorType.Multiply:
                iceSfx.Play();
                scale = (100 + (_weight * 10)) / 100f;
                currentServings *= _weight;
                
                break;
            case OperatorType.Divide:
                fireSfx.Play();
                scale = (100 - (_weight * 10)) / 100f;
                currentServings /= _weight;
                
                break;
            default:
                Debug.Log("잘못된 OperatorType 입력이 있습니다.");
                break;
        }

        if (currentServings <= 0)
        {
            Debug.Log("녹음");
            //SceneManager.LoadScene(3);
        }

        _playerStatus.ChangeSize(currentServings);
        _conditions.CheckSize(currentServings);
        Debug.Log($"{currentServings}");

        _playerTransform.localScale *= scale;

        if (_playerTransform.localScale.x > _maxSize)
        {
            _playerTransform.localScale = new Vector3(_maxSize, _maxSize, _maxSize);
        }
        else if (_playerTransform.localScale.x < _minSize)
        {
            _playerTransform.localScale = new Vector3(_minSize, _minSize, _minSize);
        }

        _playerTransform.position = new Vector3(_playerTransform.position.x,
        _playerTransform.localScale.y / 6,
        _playerTransform.position.z);

        gameObject.SetActive(false);
    }
}
