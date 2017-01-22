using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOutside : MonoBehaviour
{

    public Animator animator;

    public void OnTriggerEnter(Collider collider)
    {
        animator.SetBool("BoolOutside", true);
    }

    public void OnTriggerExit(Collider collider)
    {
        animator.SetBool("BoolOutside", false);
    }

}
