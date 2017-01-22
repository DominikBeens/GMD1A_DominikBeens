using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour
{

    public int gunDamage = 1;
    public float fireRate = 0.25f;
    public float weaponRange = 50f;
    public float hitForce = 100f;

    public Camera cam;
    private WaitForSeconds shotDuration = new WaitForSeconds(0.07f);
//    private AudioSource gunAudio;
    public float nextFire;

    public static object Animations { get; internal set; }

    void Start()
    {
//        gunAudio = GetComponent<AudioSource>();
//        fpsCam = GetComponentInParent<Camera>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            StartCoroutine(ShotEffect());

            Vector3 rayOrigin = cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;


            if (Physics.Raycast(rayOrigin, cam.transform.forward, out hit, weaponRange))
            {

                ShootableBox health = hit.collider.GetComponent<ShootableBox>();

                if (health != null)
                {
                    health.Damage(gunDamage);
                }

                if (hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * hitForce);
                }
            }
        }
    }

    private IEnumerator ShotEffect()
    {
        yield return shotDuration;
    }
}
