using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Addtoinv : MonoBehaviour
{
    public Inventory inventory;

    private void Start()
    {
        StartCoroutine(Test());
    }

    public IEnumerator Test()
    {
        yield return new WaitForSeconds(1);
        inventory.AddItem(gameObject);
    }
}
