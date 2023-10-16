using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    #region variable
    
   [SerializeField]  private float horizontalMovement;
   [SerializeField]  private float verticalMovement;
   [SerializeField] private StatsCharacter player;
   // private float speed = 8f;
   // private float jumpPower= 16f;
    public InputGame input = null;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator animator;
    private SpriteRenderer sprite;
    public bool isClimbing;
    private Vector3 velocity;

    public static PlayerController instance;
    #endregion


    private void Awake()
    {
        if(instance!=null)
        {
            Debug.Log("Plusieurs player controller");
            return;
        }
        instance = this;
        input = new InputGame();
    }

    private void OnEnable()
    {
        input.Enable();
      //  input.Player.Movement.performed += OnMovementPerformed;
        //input.Player.Movement.canceled += OnMovementCancelled;
    }
    private void OnDisable()
    {
        input.Disable();
        //input.Player.Movement.performed -= OnMovementPerformed;
        //input.Player.Movement.canceled -= OnMovementCancelled;
    }

   /* private void OnMovementPerformed(InputGame.CallbackContext value)
    {

    }
    private void OnMovementCancelled(InputGame.CallbackContext value)
    {

    }*/
    // Start is called before the first frame update
    void Start()
    {
        player.PrintData();
        sprite = transform.GetChild(1).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
       
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

    public void Move()
    {
        horizontalMovement = input.Player.Movement.ReadValue<Vector2>().x * player.speed;
        if(horizontalMovement <0f)
        {
            sprite.flipX = true;
        }
        else if(horizontalMovement >0f)
        {
            sprite.flipX = false;
        }
        rb.velocity = Vector3.SmoothDamp(rb.velocity,new Vector2(horizontalMovement,rb.velocity.y),ref velocity,.05f);
    }
    public void Jump(InputAction.CallbackContext context)
    {
        if(context.performed && IsGrounded())
        {
            rb.AddForce(new Vector2(0,player.jumpPower));
        }
        if(context.canceled && rb.velocity.y>0f)
        {
            rb.velocity = new Vector2(rb.velocity.x,rb.velocity.y*.5f);
        }
    }
    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer);
    }

    #endregion
}
