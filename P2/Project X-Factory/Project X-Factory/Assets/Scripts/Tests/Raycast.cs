using UnityEngine;
using System.Collections;

public class Raycast : MonoBehaviour
{

    public int gunDamage = 50;
    public float weaponRange = 10f;
    public Camera cam;
    public float hitForce = 100f;


    void Start ()
    {

    }

    void Update()
    {
        //Physics.Raycast(transform.position, enemy.transform.position, 10f)

        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
            RaycastHit hit;

            if (Physics.Raycast(rayOrigin, cam.transform.forward, out hit, weaponRange))
            {
                Enemy health = hit.collider.GetComponent<Enemy>();

                if (health != null)
                {
                    // Call the damage function of that script, passing in our gunDamage variable
                    health.Damage(gunDamage);
                }
                if (hit.rigidbody != null)
                {
                    // Add force to the rigidbody we hit, in the direction from which it was hit
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }

            }
        }
    }
}