using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{

    public GameObject itemPrefab;

    public Sprite itemSprite;

    public string itemName;

    public float itemPrice;

    public float itemWeight;

    public bool canStack;
}