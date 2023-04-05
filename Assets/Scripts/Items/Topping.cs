using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ItemInterface;
using System.Runtime.CompilerServices;
using Unity.VisualScripting.FullSerializer.Internal;

public class Topping : Items
{
    [SerializeField] private AudioSource toppingSfx;
    public enum ToppingType
    {
        None,
        Yogurt,
        Watermelon,
        Orange,
        Lemon,
        Kiwi,
        Grape,
        Cherry,
        Banana,
        Apple,
        Strawberry
    }
    public ToppingType _toppingType;
    [SerializeField] float _offset = 0.25f;
    public override void EffectToPlayer()
    {
        toppingSfx.Play();

        Transform playerTransform = _player.transform;
        Vector3 defaultSize = transform.localScale / 2;
        GameObject previousTopping = playerTransform.Find(_playerStatus._currentTopping.gameObject.name).gameObject;

        //SoundManager.instance.PlaySoundEffect(sound_Topping);

        previousTopping.SetActive(false);

        _playerStatus.ChangeItem(this);
        _conditions.CheckToppings(_playerStatus._currentTopping);

        if (playerTransform.Find(gameObject.name) == null)
        {
            transform.SetParent(playerTransform);
            transform.localPosition = new Vector3(0, _offset, 0);
            transform.localScale = defaultSize;
            transform.gameObject.GetComponent<SphereCollider>().enabled = false;
        }
        else
        {
            playerTransform.Find(gameObject.name).gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
