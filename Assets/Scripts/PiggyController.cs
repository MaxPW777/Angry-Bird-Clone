using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiggyController : MonoBehaviour
{
    [SerializeField] private GameObject terminator;
    private void OnCollisionEnter2D(Collision2D other)
    {
        
        if (other.relativeVelocity.magnitude > 1 || other.gameObject == terminator) 
        {
            Debug.Log("Hit detected with sufficient velocity");
        }
    }
}
