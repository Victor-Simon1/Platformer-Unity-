using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region variable
    
   [SerializeField]  private float horizontalMovement;
   [SerializeField] private StatsCharacter player;
   // private float speed = 8f;
   // private float jumpPower= 16f;


    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;
    private SpriteRenderer sprite;
    private bool climbLadder;
    private Vector3 velocity;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        player.PrintData();
        sprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       horizontalMovement = Input.GetAxisRaw("Horizontal")*player.speed * Time.deltaTime; 
       if(Input.GetButtonDown("Jump") && IsGrounded()) Jump();
       if(Input.GetButtonDown("Jump") && rb.velocity.y >0f)
            rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y*0.5f);

        if(horizontalMovement <0f)
        {
            sprite.flipX = true;
        }
        else if(horizontalMovement >0f)
        {
            sprite.flipX = false;
        }
        else
        {

        }
    }

    void FixedUpdate() 
    {
        Move();
        animator.SetFloat("Speed",Mathf.Abs(rb.velocity.x));
        //Debug.Log(animator.GetFloat("Speed"));
    }
    
    #region publicFunction
    public void ClimbLadder()
    {
         rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y*0.5f);
    }
    #endregion
    #region privateFunction

    private void Move()
    {
        rb.velocity = Vector3.SmoothDamp(rb.velocity,new Vector2(horizontalMovement,rb.velocity.y),ref velocity,.05f);
    }
    private void Jump()
    {
        rb.AddForce(new Vector2(0,player.jumpPower));
   
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer);
    }

    #endregion
}
