using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public abstract class EnnemyController : MonoBehaviour
{
    [SerializeField] protected StatsCharacter stats;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject leftStop;
    [SerializeField] private GameObject rightStop;
    private Vector3 velocity;
    private SpriteRenderer sprite;
    private GameObject target;
    private GameObject parent;
    private float dir = 1f;
    [SerializeField]protected float actualSpeed;

    // Start is called before the first frame update
    void Start()
    {
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        parent = transform.parent.gameObject;
        actualSpeed = stats.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > rightStop.transform.position.x) 
        {
            dir = -1f;
            //sprite.flipX = true;
            Vector3 scale =transform.localScale ;
            scale.Set(-1f,scale.y,scale.z);
            transform.localScale = scale;
        }
        if(transform.position.x < leftStop.transform.position.x) 
        {
            dir = 1f;
            //sprite.flipX = false;
            Vector3 scale = transform.localScale ;
            scale.Set(1f,scale.y,scale.z);
            transform.localScale = scale;
        }
    }

    void FixedUpdate()
    {
        Move();
    }
    protected void Move()
    {
        if(!target)
        {
            float horizontalMovement = actualSpeed * Time.deltaTime * dir ;
            rb.velocity = Vector3.SmoothDamp(rb.velocity,new Vector2(horizontalMovement,rb.velocity.y),ref velocity,.05f);
        }
        else GoToTarget(target,actualSpeed * Time.deltaTime);
    }


    private void GoToTarget(GameObject target,float step)
    {
        sprite.flipX = Mathf.Sign(target.transform.position.x -transform.position.x) == -1;
        float horizontalMovement = actualSpeed * Time.deltaTime * Mathf.Sign(target.transform.position.x -transform.position.x  );
        rb.velocity = Vector3.SmoothDamp(rb.velocity,new Vector2(horizontalMovement,rb.velocity.y),ref velocity,.05f);
    }

    protected abstract void OnDrawGizmos();
    protected abstract void DamagePlayer();
   /* private void OnTriggerEnter2D(Collider2D other) 
    {
        if("Player".Equals(other.tag) )
        {
            target = other.gameObject;
            
        }
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if("Player".Equals(other.tag) )
        {
            target = null;
        }
    }*/
     /*private void OnCollisionEnter2D(Collision2D other) 
    {
        if("Player".Equals(other.transform.tag))
        {
            PlayerHealth playerHealth = other.transform.GetComponent<PlayerHealth>();
            
            playerHealth.TakeDamage(20);
           
        }
    }*/
}
