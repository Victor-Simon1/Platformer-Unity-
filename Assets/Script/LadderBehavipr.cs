using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderBehavipr : MonoBehaviour
{

    private bool playerOnLadder = false;
    [SerializeField]
    private PlayerController playerController; 
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        
         Debug.Log("Je touche une échelle");
        //playerController.ClimbLadder();
    }
}
