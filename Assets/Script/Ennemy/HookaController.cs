using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookaController : EnnemyController
{

    public BoxCollider2D boxCollider;
    public float range = 2f;
    public float colliderDistance = 0.8f;
    public LayerMask playerLayer;
    //Is an basic melee ennemy 

    public bool PlayerInSight()
    {
        RaycastHit2D hit  = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
                                                new Vector3(boxCollider.bounds.size.x*range,boxCollider.bounds.size.y,boxCollider.bounds.size.z),
                                                0,
                                                Vector2.left,
                                                0,
                                                playerLayer);

        return hit.collider != null;
    }
    //Call on animator
    protected override void DamagePlayer()
    {
        if(PlayerInSight())
        {
            Debug.Log("Damage to player");
            PlayerHealth.instance.TakeDamage(20);
        }
        else  Debug.Log( " No Damage to player");
    }

    protected override void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x* colliderDistance,
                            new Vector3(boxCollider.bounds.size.x*range,boxCollider.bounds.size.y,boxCollider.bounds.size.z));
    }
}
