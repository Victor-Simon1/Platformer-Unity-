using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostScript : MonoBehaviour
{
    public BoostEffect boostEffect;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        boostEffect.Apply(collider.gameObject);
    }
}
