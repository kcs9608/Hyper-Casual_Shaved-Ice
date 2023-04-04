using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemInterface;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Operator : Items
{
    [SerializeField] private AudioSource iceSfx;
    [SerializeField] private AudioSource fireSfx;

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
            SceneManager.LoadScene(3);
            return;
        }

        _playerStatus.ChangeSize(currentServings);
        _conditions.CheckSize(currentServings);
        Debug.Log($"{currentServings}");

        _playerTransform.localScale *= scale;

        if (_playerTransform.localScale.x > 1.5f)
        {
            _playerTransform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        }
        else if (_playerTransform.localScale.x < 0.2f)
        {
            _playerTransform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        }

        _playerTransform.position = new Vector3(_playerTransform.position.x,
        _playerTransform.localScale.y / 2,
        _playerTransform.position.z);

        gameObject.SetActive(false);
    }
}
