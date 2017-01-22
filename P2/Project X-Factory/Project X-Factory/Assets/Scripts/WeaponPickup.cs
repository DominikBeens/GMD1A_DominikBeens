using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponPickup : MonoBehaviour
{
    public UI_Manager uim;

    public GameObject showWeapon;
    public GameObject realWeapon;
    public GameObject enemySpawner;
    public Animator animator;

    public bool gunInInv = false;
    public bool knifeInInv = false;

    public Weaponchange weaponChange;

    void Start ()
    {
        enemySpawner.SetActive(false);
    }

    void Update ()
    {
        if (realWeapon.activeInHierarchy == true)
        {
            gunInInv = true;
        }
        else
        {
            gunInInv = false;
        }
    }

    public void OnTriggerStay(Collider collider)
    {
        if (collider.tag == "Player")
        {
            uim.weaponPickupPanel.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E) && showWeapon.activeInHierarchy == true)
        {
            weaponChange.weapons.Add(realWeapon);
            showWeapon.SetActive(false);
            enemySpawner.SetActive(true);
            StartCoroutine(SpawnerActivate());
        }
        else if (Input.GetKeyDown(KeyCode.E) && showWeapon.activeInHierarchy == false)
        {
            realWeapon.SetActive(false);
            weaponChange.weapons.Remove(realWeapon);
            showWeapon.SetActive(true);
        }
    }

    public void OnTriggerExit(Collider collider)
    {
        uim.weaponPickupPanel.SetActive(false);
    }

    public IEnumerator SpawnerActivate()
    {
        animator.SetBool("Spawner Activate", true);
        yield return new WaitForSeconds(2.6f);
        animator.SetBool("Spawner Activate", false);
        uim.weaponPickupText.text = ("");
    }
}
