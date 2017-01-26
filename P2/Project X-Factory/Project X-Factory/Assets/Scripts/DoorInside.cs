using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInside : MonoBehaviour
{
    // ik kon de beide animaties voor het openen en sluiten niet in 1 script krijgen

    public Animator animator;

    public void OnTriggerEnter(Collider collider)
    {
        animator.SetBool("BoolInside", true);
    }

    public void OnTriggerExit(Collider collider)
    {
        animator.SetBool("BoolInside", false);
    }

}
