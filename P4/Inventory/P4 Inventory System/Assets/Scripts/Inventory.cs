using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public List<InventorySlot> inventorySlot = new List<InventorySlot>();
    public Transform itemSlotLayoutGroup;

    public static bool itemHolding;
    public static bool movingItem;
    public static Entity itemBuffer;
    public static Entity itemSwapVar;
    public static Image itemBufferImage;

    private void Start()
    {
        itemSlotLayoutGroup = transform.GetChild(0);

        //Creating an Image to display what item were dragging
        itemBufferImage = new GameObject().AddComponent<Image>();
        itemBufferImage.raycastTarget = false;
        itemBufferImage.transform.SetParent(transform);
        itemBufferImage.enabled = false;

        foreach (Transform child in itemSlotLayoutGroup)
        {
            if (child.GetChild(0).GetComponent<InventorySlot>() != null)
            {
                inventorySlot.Add(child.GetChild(0).GetComponent<InventorySlot>());
            }
        }
    }

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
