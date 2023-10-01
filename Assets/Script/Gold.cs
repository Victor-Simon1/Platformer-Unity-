using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gold : CollectibleObject
{
    //GameManager gm;
    protected override void ActionToMake()
    {
        //gm.AddGold();
        Debug.Log("Collect gold");
        Destroy(gameObject);
    }
}
