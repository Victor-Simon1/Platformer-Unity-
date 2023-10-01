using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectibleObject : MonoBehaviour
{
   
    protected abstract void ActionToMake();
    void OnTriggerEnter2D(Collider2D other)
    {
        if("Player".Equals(other.tag) )
        {
            Inventory.instance.AddCoins(1);
            ActionToMake();
        }
    }
}
