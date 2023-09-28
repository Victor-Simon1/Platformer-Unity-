using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using Unity.VisualScripting;
using UnityEngine;

public class EnnemyController : MonoBehaviour
{
    [SerializeField] private StatsCharacter stats;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject leftStop;
    [SerializeField] private GameObject rightStop;
    private Vector3 velocity;
    private SpriteRenderer sprite;
    private GameObject target;
    private float dir = 1f;

    // Start is called before the first frame update
    void Start()
    {
        sprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x > rightStop.transform.position.x) 
        {
            dir = -1f;
            sprite.flipX = true;
        }
        if(transform.position.x < leftStop.transform.position.x) 
        {
            dir = 1f;
            sprite.flipX = false;
        }
    }

    void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        if(!target)
        {
            float horizontalMovement = stats.speed * Time.deltaTime * dir ;
            rb.velocity = Vector3.SmoothDamp(rb.velocity,new Vector2(horizontalMovement,rb.velocity.y),ref velocity,.05f);
        }
        else GoToTarget(target,stats.speed * Time.deltaTime);
    }


    private void GoToTarget(GameObject target,float step)
    {
        sprite.flipX = Mathf.Sign(target.transform.position.x -transform.position.x) == -1;
        float horizontalMovement = stats.speed * Time.deltaTime * Mathf.Sign(target.transform.position.x -transform.position.x  );
        rb.velocity = Vector3.SmoothDamp(rb.velocity,new Vector2(horizontalMovement,rb.velocity.y),ref velocity,.05f);
    }

    private void OnTriggerEnter2D(Collider2D other) 
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
    }
}
