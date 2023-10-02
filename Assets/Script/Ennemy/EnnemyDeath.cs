using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if("Player".Equals(other.tag))
        {
            transform.parent.parent.gameObject.SetActive(false);
            PlayerLevel playerLevel = other.transform.GetComponent<PlayerLevel>();
            playerLevel.AddXp(110);
        }
    }
}
