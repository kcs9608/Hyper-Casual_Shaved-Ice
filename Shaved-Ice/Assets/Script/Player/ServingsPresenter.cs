using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.UI;

public class ServingsPresenter : MonoBehaviour
{
    private PlayerStatus _status;
    [SerializeField] private Text _sizeText;
    private void Awake()
    {
        _status = GetComponent<PlayerStatus>();
        _status.StatusChanged -= UpdateText;
        _status.StatusChanged += UpdateText;
    }
    private void OnDestroy()
    {
        _status.StatusChanged -= UpdateText;
    }
    private void UpdateText()
    {
        _sizeText.text = $"{_status._currentServings}";
    }
}
