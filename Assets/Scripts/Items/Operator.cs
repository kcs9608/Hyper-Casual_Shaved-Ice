using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemInterface;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Operator : Items
{
    [Header("얼음 획득 효과음")]
    [SerializeField] string sound_Ice;

    [Header("불 획득 효과음")]
    [SerializeField] string sound_Fire;

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
    [SerializeField] private float _maxSize = 6f;
    [SerializeField] private float _minSize = 1f;

    public override void EffectToPlayer()
    {
        Transform _playerTransform = _player.GetComponent<Transform>();
        int currentServings = _playerStatus._currentServings;
        float scale = 1f;

        switch (operatorType)
        {
            case OperatorType.Add:
                scale = (100 + _weight) / 100f;
                currentServings += _weight;
                //SoundManager.instance.PlaySoundEffect(sound_Ice);
                break;
            case OperatorType.Subtract:
                scale = (100 - _weight) / 100f;
                currentServings -= _weight;
                //SoundManager.instance.PlaySoundEffect(sound_Fire);
                break;
            case OperatorType.Multiply:
                scale = (100 + (_weight * 10)) / 100f;
                currentServings *= _weight;
                //SoundManager.instance.PlaySoundEffect(sound_Ice);
                break;
            case OperatorType.Divide:
                scale = (100 - (_weight * 10)) / 100f;
                currentServings /= _weight;
                //SoundManager.instance.PlaySoundEffect(sound_Fire);
                break;
            default:
                Debug.Log("잘못된 OperatorType 입력이 있습니다.");
                break;
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
        _playerTransform.localScale.y / 8,
        _playerTransform.position.z);

        gameObject.SetActive(false);
    }
}
