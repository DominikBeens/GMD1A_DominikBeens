using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Addtoinv : MonoBehaviour
{
    private Inventory inventory;

    private void Start()
    {
        inventory = GameObject.FindWithTag("Inventory").GetComponent<Inventory>();
        inventory.AddItem(gameObject);
    }

    // dit heb ik ff op de items gezet om ze automatisch in de inventory te gooien als ze worden geinstantiate
}
