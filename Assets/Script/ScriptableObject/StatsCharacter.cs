using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Character")]
public class StatsCharacter : ScriptableObject
{
    public new string name;
    
    public int hp;
    public int atk;
    public float speed;
    public float jumpPower;


    public void PrintData()
    {
        Debug.Log("Name" + name+ " hp" + hp );
    }
}
