using ItemInterface;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class PlayerGetItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Items"))
        {
            Items item = other.GetComponent<Items>();
            item.EffectToPlayer();
        }
    }
}