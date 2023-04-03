using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemInterface;

public class Syrup : Items
{
    [SerializeField]
    private Color _color;

    public enum SyrupType
    {
        None,
        Lemon,
        Orange
    }
    public SyrupType _syrupType = (SyrupType)Random.Range(0, 2);

    public override void EffectToPlayer()
    {
        MeshRenderer playerColor = _player.GetComponent<MeshRenderer>();
        _playerStatus.ChangeItem(this);
        _conditions.CheckSyrup(this);
        playerColor.material.color = _color;
        gameObject.SetActive(false);
    }
}
