using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInside : MonoBehaviour
{

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
