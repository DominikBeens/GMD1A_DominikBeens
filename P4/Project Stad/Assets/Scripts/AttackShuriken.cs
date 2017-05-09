using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackShuriken : MonoBehaviour
{
    public int totalAmmo;
    public int currentAmmo;
    public int clipSize;
    public float reloadTime;
    public bool isReloading;
    public float attackTime = 0.25f;
    public float attackTimeStamp;
    public bool canFire;
    private GameObject player;
    public GameObject shurikenGO;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void Update()
    {
        if (totalAmmo > 0)
        {
            if (currentAmmo <= 0 && !isReloading)
            {
                canFire = false;
                StartCoroutine(Reload());
            }

            if (Time.time >= attackTimeStamp && Input.GetButton("Fire1") && canFire)
            {
                Shuriken();
                attackTimeStamp = Time.time + attackTime;

                currentAmmo--;
                totalAmmo--;
            }
        }
    }

    public void Shuriken()
    {
        Instantiate(shurikenGO, player.transform.position, Quaternion.identity);
        Physics2D.IgnoreLayerCollision(8, 9);
    }

    public IEnumerator Reload()
    {
        isReloading = true;
        yield return new WaitForSeconds(reloadTime);

        if (totalAmmo >= clipSize)
        {
            currentAmmo += clipSize;
        }
        else if (totalAmmo < clipSize)
        {
            currentAmmo += totalAmmo;
        }
        else
        {
            yield return null;
        }

        canFire = true;
        isReloading = false;
    }
}
