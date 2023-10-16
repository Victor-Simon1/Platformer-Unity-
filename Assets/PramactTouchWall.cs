using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PramactTouchWall : MonoBehaviour
{

    //changer en script torse,passer un collider en mode pied et un autre pour le torse
    [SerializeField] GameObject pramactController;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Ground"))
        {
            StartCoroutine(pramactController.GetComponent<PramactController>().HasTouchWallCoroutine());
        }
    }
}
