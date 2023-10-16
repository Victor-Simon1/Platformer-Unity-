using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentSceneManager : MonoBehaviour
{
    public Vector3 respawnPoint;
    public int levelToUnlock;
    public static CurrentSceneManager instance;

    private void Awake() 
    {
        if(instance != null)
        {
            Debug.Log("Plusieurs Scene Manager");
            return;
        }

        instance = this;

        respawnPoint = GameObject.FindGameObjectWithTag("Player").transform.position;
    }
    

   
}
