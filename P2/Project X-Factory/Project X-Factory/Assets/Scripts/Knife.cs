using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Knife : MonoBehaviour
{
    [Header("Unity Stuff")]
    public UI_Manager uim;
    public Animator animator;
    public Camera cam;

    [Header("Knife Properties")]
    public int hitDamage = 50;
    public float hitRange = 5f;
    public bool canDamage = true;

    void Update()
    {

        Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit hit;

        if (Input.GetButtonDown("Fire1") && canDamage == true)
        {
            animator.SetTrigger("Swing");

            if (Physics.Raycast(rayOrigin, cam.transform.forward, out hit, hitRange))
            {
                print(hit.collider.gameObject.name);
                Enemy health = hit.collider.GetComponent<Enemy>();

                if (health != null)
                {
                    health.Damage(hitDamage);
                }

                if (hit.collider.gameObject.tag == ("Enemy"))
                {
                    //instantiate een particle ofso
                }

            }

        }

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("KnifeSwing"))
        {
            canDamage = false;
        }
        else
        {
            canDamage = true;
        }
    } 
}
