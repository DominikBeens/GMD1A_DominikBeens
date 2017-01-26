using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    [Header("Unity Stuff")]
    public UI_Manager uim;
    public Animator animator;
    public int bullets = 4;

    public Camera cam;

    [Header("Instantiating")]
    public GameObject bulletHit;
    public GameObject bulletFire;
    public GameObject bulletFireEmpty;

    [Header("Gun Properties")]
    public int gunDamage = 50;
    public float gunRange = 10f;
    public float hitForce = 100f;
    public bool canShoot = true;

    void Update()
    {

        Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f));
        RaycastHit hit;

        if (Input.GetButtonDown("Fire1") && canShoot == true)
        {
            bullets -= 2;
            animator.SetTrigger("Shoot");
            uim.ammoCount.fillAmount -= 0.5f;
            StartCoroutine(Bullet());

            if (Physics.Raycast(rayOrigin, cam.transform.forward, out hit, gunRange))
            {
//              print(hit.collider.gameObject.name);
                Enemy health = hit.collider.GetComponent<Enemy>();

                if (health != null)
                {
                    health.Damage(gunDamage);
                }
                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }

                if (hit.collider.gameObject.tag == ("Enemy"))
                {
 //                 GameObject bulletHitSpawn = (GameObject)Instantiate(bulletHit, hit.transform.position, Quaternion.identity);
                }

            }

        }

        if (bullets == 0)
        {
            animator.SetTrigger("Reload");
            bullets = 4;
            StartCoroutine(AmmoReload());
        }

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Shoot") || this.animator.GetCurrentAnimatorStateInfo(0).IsName("Reload"))
        {
            canShoot = false;
        }
        else
        {
            canShoot = true;
        }
    }

    IEnumerator AmmoReload()
    {
        yield return new WaitForSeconds(1.0f);
        uim.ammoCount.fillAmount = 1;
    }

    IEnumerator Bullet()
    { 
        GameObject bulletFireSpawn = (GameObject)Instantiate(bulletFire, bulletFireEmpty.transform.position, bulletFireEmpty.transform.rotation);
        yield return new WaitForSeconds(0.2f);
        Destroy(bulletFireSpawn);
    }
}
