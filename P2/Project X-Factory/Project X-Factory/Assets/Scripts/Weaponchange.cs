using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaponchange : MonoBehaviour
{

    public int currentWeapon;
    public List<GameObject> weapons = new List<GameObject>();
	
	void Update ()
    {
        if (Input.GetButtonDown("Jump"))
        {
            changeWeapon(1);
        }
    }

    public void changeWeapon(int number)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if (currentWeapon == 0)
            {
                weapons[0].SetActive(true);
                weapons[1].SetActive(false);
            }
            else if (currentWeapon == 1)
            {
                weapons[0].SetActive(false);
                weapons[1].SetActive(true);
            }

            if (weapons.Count == 1)
            {
                weapons[i].SetActive(true);
            }
        }

        currentWeapon++;
        currentWeapon %= weapons.Count;
    }
}
