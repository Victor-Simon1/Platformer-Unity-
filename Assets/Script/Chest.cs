using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Chest : MonoBehaviour
{
    private bool isInRange;
    private TextMeshProUGUI interactUI;
    public Animator animator;

    private void Awake()
    {
        interactUI = GameObject.FindGameObjectWithTag("InteractUI").GetComponent<TextMeshProUGUI>();
    }
    private void Update()
    {
        float input = PlayerController.instance.input.Player.OpenChest.ReadValue<float>();
        if(input!=0f && isInRange)
        {
            OpenChest();
        }
    }

    private void OpenChest()
    {
        animator.SetBool("isOpen",true);
        Inventory.instance.AddCoins(10);
        GetComponent<BoxCollider2D>().enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
            if(collider.CompareTag("Player")) 
            {
                isInRange = true;
                interactUI.enabled = true;
            }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {
            if(collider.CompareTag("Player")) 
            {
                isInRange = false;
                interactUI.enabled = false;
            }
    }
}
