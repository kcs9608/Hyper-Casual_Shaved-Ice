using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemInterface;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Operator : Items
{
    [Header("¾óÀ½ È¹µæ È¿°úÀ½")]
    [SerializeField] string sound_Ice;

    [Header("ºÒ È¹µæ È¿°úÀ½")]
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
                Debug.Log("Àß¸øµÈ OperatorType ÀÔ·ÂÀÌ ÀÖ½À´Ï´Ù.");
                break;
        }

        if (currentServings <= 0)
        {
            Debug.Log("³ìÀ½");
            SceneManager.LoadScene("SampleScene");
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
