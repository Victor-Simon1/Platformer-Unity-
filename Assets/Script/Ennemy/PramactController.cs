using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PramactController : EnnemyController
{   
    public BoxCollider2D boxCollider;
    public float range = 6f;
    public float colliderDistance = 0.8f;
    public float height = 0.8f;
    public LayerMask playerLayer;
    public Animator anim;

    private bool looseSight;
    [SerializeField] private bool isStun;
    [SerializeField] private BoxCollider2D deathCollider;
    //Charge the player when near

    public void GoOnChargeMode()
    {
        if(PlayerInSight())
        {
            anim.SetTrigger("Charge");
            actualSpeed =200;
        }
    }
    public void ReturnToWalk()
    {
        if(!PlayerInSight() && !looseSight)
        {
            looseSight = true;
            StartCoroutine(CoroutineToWalk());
        }
    }
    public bool PlayerInSight()
    {
        RaycastHit2D hit  = Physics2D.BoxCast(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
                                                new Vector3(boxCollider.bounds.size.x*range,boxCollider.bounds.size.y*height,boxCollider.bounds.size.z),
                                                0,
                                                Vector2.left,
                                                0,
                                                playerLayer);

        return hit.collider != null;
    }
    protected override void DamagePlayer()
    {
        PlayerHealth.instance.TakeDamage(25);
    }

    
    protected override void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(boxCollider.bounds.center + transform.right * range * transform.localScale.x * colliderDistance,
                            new Vector3(boxCollider.bounds.size.x*range,boxCollider.bounds.size.y*height,boxCollider.bounds.size.z));
    }

    private IEnumerator CoroutineToWalk()
    {
        yield return new WaitForSeconds(2f);
        actualSpeed =stats.speed;
        anim.SetBool("Walk",true);
        Debug.Log("Repasse en walk");
        looseSight = false;
    }

    public IEnumerator HasTouchWallCoroutine()
    {
           isStun = true;
        //anim.SetBool("Stun",true);
        deathCollider.enabled = true;
        yield return new WaitForSeconds(2f);
        isStun = false;
    }
     private void OnCollisionEnter2D(Collision2D other) 
    {
        if("Player".Equals(other.transform.tag))
        {
           DamagePlayer(); 
        }
    }

}
