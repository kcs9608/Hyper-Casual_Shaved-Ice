using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemInterface;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.FullSerializer.Internal;

public class Topping : Items
{
    public enum ToppingType
    {
        None,
        Strawberry,
        Chocolate,
        Mango,
    }
    public ToppingType _toppingType;
    [SerializeField] float _offset = 1f;

    [SerializeField] private AudioSource toppingSfx;

    public override void EffectToPlayer()
    {
        toppingSfx.Play();

        Transform playerTransform = _player.transform;
        Vector3 defaultSize = transform.localScale * 2;
        GameObject previousTopping = playerTransform.Find(_playerStatus._currentTopping.gameObject.name).gameObject;

        previousTopping.SetActive(false);

        _playerStatus.ChangeItem(this);
        _conditions.CheckToppings(_playerStatus._currentTopping);

        if (playerTransform.Find(gameObject.name) == null)
        {
            transform.SetParent(playerTransform);
            transform.localPosition = new Vector3(0, _offset, 0);
            transform.localScale = defaultSize;
        }
        else
        {
            playerTransform.Find(gameObject.name).gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
