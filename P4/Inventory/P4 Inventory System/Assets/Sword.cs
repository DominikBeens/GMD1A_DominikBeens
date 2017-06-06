using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Inventory inventory;

    private void Start()
    {
        inventory.AddItem(gameObject);
    }
}
