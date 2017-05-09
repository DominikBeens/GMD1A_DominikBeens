using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{

    public int health;
    public GameObject wapen;
    public int defense;
    public int speed;
    public int weaponskill;

	void Start()
    {
        Wpskill();
    }
	
	void Update()
    {
        //Die();
    }

    public void Die()
    {
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Def()
    {

    }

    public void Spd()
    {
       
    }

    public void Wpskill()
    {
        foreach (Transform child in gameObject.transform)
            if (child.CompareTag("Weapon"))
            {
                wapen = child.gameObject;
            }
       Weapon wp = wapen.GetComponent<Weapon>();
       wp.damage += weaponskill;
    }
}
