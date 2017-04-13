using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public float walkSpeed;
    public float runSpeed;
    public float currentSpeed;
    public float rotateSpeed = 30f;

    //public float jumpSpeed = 5.0f;
    //public float jumpGravity = 20.0f;

    public Animator anim;

    //niet precies wat ik wilde, maar het werkt
    //ben er nog mee bezig

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal") * Time.deltaTime * rotateSpeed;
        float vertical = Input.GetAxis("Vertical") * Time.deltaTime * currentSpeed;

        transform.Rotate(0, horizontal, 0);
        transform.Translate(0, 0, vertical);

        //walking
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            anim.SetBool("Walking", true);
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            anim.SetBool("Walking", false);
        }

        //running
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("Running", true);
            currentSpeed = runSpeed;
        }
        else
        {
            anim.SetBool("Running", false);
            currentSpeed = walkSpeed;
        }

        ////jumping
        //if (Input.GetButtonDown("Jump"))
        //{
        //    anim.SetTrigger("Jump");
        //    transform.Translate(0, jumpSpeed, 0);           
        //}
    }
}