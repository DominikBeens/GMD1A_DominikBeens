using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //inventory stuff
    public List<InventorySlot> inventorySlot = new List<InventorySlot>();
    public Transform itemSlotLayoutGroup;

    public GameObject inventory;
    public bool inventoryOpen;
    public static bool itemHolding;
    public static bool movingItem;
    public static Entity itemBuffer;
    public static Entity itemSwapVar;
    public static Image itemBufferImage;
    public static int quantityItemHolding;
    public static int quantitySwapVar;
    public static bool canUnstack;

    //add item
    public List<GameObject> items = new List<GameObject>();
    public int randomItemNumber;

    private void Start()
    {
        inventory = transform.GetChild(0).gameObject;
        itemSlotLayoutGroup = transform.GetChild(0).transform.GetChild(0);

        //Creating an image to display what item were dragging
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

    private void Update()
    {
        if (movingItem)
        {
            itemBufferImage.sprite = itemBuffer.item.itemSprite;
            itemBufferImage.transform.position = Input.mousePosition;
        }

        if (Input.GetButton("Sprint"))
        {
            canUnstack = true;
        }
        else
        {
            canUnstack = false;
        }
    }

    public void AddRandomItem()
    {
        randomItemNumber = Random.Range(0, items.Count);
        Instantiate(items[randomItemNumber], transform.position, Quaternion.identity);
    }

    public void DeleteItem()
    {
        if (itemBuffer != null)
        {
            Destroy(itemBuffer.gameObject);
            itemBuffer = null;
            itemBufferImage.enabled = false;
            itemHolding = false;
            movingItem = false;
        }
    }

    public void DeleteAllItems()
    {
        foreach (Transform child in itemSlotLayoutGroup)
        {
            if (child.GetChild(0).GetComponent<InventorySlot>().currentItem != null)
            {
                Destroy(child.GetChild(0).GetComponent<InventorySlot>().currentItem.gameObject);
            }
        }
    }

    //function to call from an item you want to add to the inventory
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

    public void ToggleInventory()
    {
        if (inventoryOpen)
        {
            inventory.SetActive(false);
            inventoryOpen = false;
        }
        else if (!inventoryOpen)
        {
            inventory.SetActive(true);
            inventoryOpen = true;
        }
    }
}
