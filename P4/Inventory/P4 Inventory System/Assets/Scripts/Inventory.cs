using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [Header("Inventory")]
    public List<InventorySlot> inventorySlot = new List<InventorySlot>();
    public Transform itemSlotLayoutGroup;

    public GameObject inventoryPanel;
    public bool inventoryOpen;
    public static bool holdingItem;
    public static Entity itemBuffer;
    public static Entity itemSwapVar;
    public Image itemBufferImage;
    public static int quantityItemHolding;
    public static int quantitySwapVar;
    public static bool canUnstack;

    [Header("Stats")]
    public GameObject statsPanel;
    public Text statsText;

    [Header("Items")]
    public List<GameObject> items = new List<GameObject>();
    public int randomItemNumber;

    [Header("Item Preview")]
    public bool canPreviewItem;
    public bool previewPanelActive;
    public GameObject itemPreviewPanel;
    public Transform itemPreviewSpawn;
    public GameObject slotHoveredOver;
    public GameObject spawnedPreviewItem;
    public bool rotateItemPreview;

    private void Start()
    {
        inventoryPanel = transform.GetChild(0).gameObject;

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
        if (holdingItem)
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
            holdingItem = false;
        }
    }

    public void DeleteAllItems()
    {
        foreach (Transform child in itemSlotLayoutGroup)
        {
            if (child.GetChild(0).GetComponent<InventorySlot>().currentItem != null)
            {
                Destroy(child.GetChild(0).GetComponent<InventorySlot>().currentItem.gameObject);
                child.GetChild(0).GetComponent<InventorySlot>().quantity = 1;
            }
        }
    }

    // function to call from an item you want to add to the inventory, for when you pick it up etc
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
            inventoryPanel.SetActive(false);
            inventoryOpen = false;
        }
        else if (!inventoryOpen)
        {
            inventoryPanel.SetActive(true);
            inventoryOpen = true;
        }
    }
}
