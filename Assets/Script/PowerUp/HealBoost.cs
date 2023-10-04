using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="Boost")]
public class HealBoost : BoostEffect
{
    public int amount;
    public override void Apply(GameObject target)
    {
       
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        playerHealth.HealPlayer(amount);
    }
}
