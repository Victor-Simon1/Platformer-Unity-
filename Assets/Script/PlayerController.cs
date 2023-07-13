using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    #region variable
    
   [SerializeField]  private float horizontal;
   [SerializeField] private StatsCharacter player;
   // private float speed = 8f;
   // private float jumpPower= 16f;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        player.PrintData();
    }

    // Update is called once per frame
    void Update()
    {
       horizontal = Input.GetAxisRaw("Horizontal"); 
       if(Input.GetButtonDown("Jump") && IsGrounded()) Jump();
       if(Input.GetButtonDown("Jump") && rb.velocity.y >0f)
            rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y*0.5f);
    }

    void FixedUpdate() 
    {
        rb.velocity = new Vector2(horizontal*player.speed,rb.velocity.y);
    }


    #region privateFunction

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x,player.jumpPower);
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer);
    }

    #endregion
}
