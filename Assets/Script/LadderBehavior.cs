using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderBehavior : MonoBehaviour
{

    private bool isInRange = false;
    [SerializeField]
    private PlayerController playerController; 
    private Collider2D colliderGround; 
    // Start is called before the first frame update
    void Awake()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        colliderGround = transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isInRange && Input.GetAxis("Vertical") != 0)
        {
            playerController.isClimbing = true;
            colliderGround.isTrigger = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) 
    {
        if(collider.CompareTag("Player"))
        {
            isInRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collider) 
    {
        if(collider.CompareTag("Player"))
        {
            isInRange = false;
            playerController.isClimbing = false;
            colliderGround.isTrigger = false;
        }
    }
   /* private void OnCollisionExit2D(Collision2D collider) 
    {
        if(collider.CompareTag("Player"))
        {
            isInRange = false;
            playerController.isClimbing = false;
            colliderGround.isTrigger = false;
        }
    }*/
}
