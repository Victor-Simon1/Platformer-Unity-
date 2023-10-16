using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Boost")]
public class HealBoost : BoostEffect
{
    public int amount;
    public override void Apply(GameObject target)
    {
       
        Player playerHealth = target.GetComponent<Player>();
        playerHealth.HealPlayer(amount);
    }
}
