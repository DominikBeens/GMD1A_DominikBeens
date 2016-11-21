using UnityEngine;
using System.Collections;

public class Weaponchange : MonoBehaviour
{

    public int currentWeapon;
    public Transform[] weapons;

    void Start ()
    {
	
	}
	
	void Update ()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            changeWeapon(1);
        }
    }

    public void changeWeapon(int num)
    {
        currentWeapon++;  
        currentWeapon %= weapons.Length;

        for (int i = 0; i < weapons.Length; i++)
        {
            if (i == num)
                weapons[i].gameObject.SetActive(true);
            else
                weapons[i].gameObject.SetActive(false);
        }
    }
}
