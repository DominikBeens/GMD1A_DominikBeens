using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{

    public List<InventorySlot> inventorySlot = new List<InventorySlot>();

    public static bool itemHolding;
    public static Entity itemBuffer;

    public void AddItem(GameObject item)
    {
        for (int i = 0; i < inventorySlot.Count; i++)
        {
            if (inventorySlot[i].currentItem == null)
            {
                inventorySlot[i].currentItem = item.GetComponent<Entity>();
                if (item.GetComponent<Entity>() == null)
                {
                    Debug.LogError("NO ITEM SCRIPT ON ITEM BUT INVENTORY IS TRYING TO ADD IT");
                }
                return;
            }
        }
    }
}
