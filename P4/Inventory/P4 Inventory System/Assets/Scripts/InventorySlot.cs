using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{

    private Inventory inv;
    public Entity currentItem;
    public Sprite emptySlotImage;
    public int quantity = 1;
    public Text quantityText;

    private void Start()
    {
        inv = GameObject.FindWithTag("Inventory").GetComponent<Inventory>();
        quantityText = GetComponentInChildren<Text>();
    }

    private void Update()
    {
        if (inv.statsPanel.activeInHierarchy)
        {
            inv.statsPanel.transform.position = Input.mousePosition;
        }

        if (currentItem != null)
        {
            GetComponent<Image>().sprite = currentItem.item.itemSprite;
        }
        else if (currentItem == null)
        {
            GetComponent<Image>().sprite = emptySlotImage;
        }

        if (quantity > 1)
        {
            quantityText.text = quantity.ToString();
        }
        else if (quantity <= 1)
        {
            quantityText.text = null;
        }

        // item preview
        if (inv.canPreviewItem && !inv.previewPanelActive && !Inventory.itemBuffer)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                inv.itemPreviewPanel.SetActive(true);
                inv.previewPanelActive = true;

                if (inv.itemPreviewSpawn.childCount == 0)
                {
                    inv.spawnedPreviewItem = Instantiate(inv.slotHoveredOver.GetComponent<InventorySlot>().currentItem.item.itemPrefab, inv.itemPreviewSpawn.position, Quaternion.identity);
                    inv.spawnedPreviewItem.transform.SetParent(inv.itemPreviewSpawn);
                    inv.spawnedPreviewItem.GetComponent<Addtoinv>().enabled = false;
                    inv.rotateItemPreview = true;
                }
                else if (inv.itemPreviewSpawn.childCount > 0)
                {
                    Destroy(inv.itemPreviewSpawn.GetChild(0).gameObject);
                    inv.spawnedPreviewItem = Instantiate(inv.slotHoveredOver.GetComponent<InventorySlot>().currentItem.item.itemPrefab, inv.itemPreviewSpawn.position, Quaternion.identity);
                    inv.spawnedPreviewItem.transform.SetParent(inv.itemPreviewSpawn);
                    inv.spawnedPreviewItem.GetComponent<Addtoinv>().enabled = false;
                    inv.rotateItemPreview = true;
                }
            }

        }
        if (inv.previewPanelActive)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                inv.itemPreviewPanel.SetActive(false);
                inv.previewPanelActive = false;
                inv.rotateItemPreview = false;
            }
        }

        if (inv.rotateItemPreview)
        {
            inv.spawnedPreviewItem.transform.Rotate(new Vector3(0, 1 * Time.deltaTime, 0));
        }
    }

    public void MouseOver()
    {
        if (currentItem != null)
        {
            inv.statsText.text = currentItem.item.itemName + "\n" + "Price: " + currentItem.item.itemPrice + "\n" + "Weight: " + currentItem.item.itemWeight;
            inv.statsPanel.SetActive(true);
            inv.slotHoveredOver = this.gameObject;

            if (!Inventory.holdingItem)
            {
                inv.canPreviewItem = true;
            }
        }
    }

    public void MouseClick()
    {
        if (!Inventory.holdingItem && currentItem != null)
        {
            if (!Inventory.canUnstack)
            {
                PickUpItem();
            }
            else if (Inventory.canUnstack)
            {
                if (currentItem.item.canStack && quantity > 1)
                {
                    UnstackItem();
                }
            }
        }
        else if (Inventory.holdingItem && currentItem == null)
        {
            PlaceItem();
        }
        else if (Inventory.holdingItem && currentItem != null)
        {
            if (!Inventory.itemBuffer.item.canStack || Inventory.itemBuffer.item.canStack && !currentItem.item.canStack)
            {
                SwitchItem();
            }
            else if (Inventory.itemBuffer.item.canStack && currentItem.item.canStack && Inventory.itemBuffer.item.itemID == currentItem.item.itemID)
            {
                StackItem();
            }
        }
    }

    public void PickUpItem()
    {
        Inventory.holdingItem = true;
        Inventory.itemBuffer = currentItem;
        inv.itemBufferImage.enabled = true;
        currentItem = null;
        Inventory.quantityItemHolding = quantity;
        quantity = 1;
        inv.statsPanel.SetActive(false);
    }

    public void PlaceItem()
    {
        Inventory.holdingItem = false;
        currentItem = Inventory.itemBuffer;
        Inventory.itemBuffer = null;
        inv.itemBufferImage.enabled = false;
        quantity = Inventory.quantityItemHolding;
    }

    public void SwitchItem()
    {
        Inventory.itemSwapVar = currentItem;
        Inventory.quantitySwapVar = quantity;
        currentItem = Inventory.itemBuffer;
        quantity = Inventory.quantityItemHolding;
        Inventory.itemBuffer = Inventory.itemSwapVar;
        Inventory.quantityItemHolding = Inventory.quantitySwapVar;
    }

    public void StackItem()
    {
        Inventory.itemBuffer = null;
        inv.itemBufferImage.enabled = false;
        Inventory.holdingItem = false;

        if (currentItem.item.canStack && Inventory.quantityItemHolding == 1)
        {
            quantity++;
        }
        else if (currentItem.item.canStack && Inventory.quantityItemHolding >= 1)
        {
            quantity += Inventory.quantityItemHolding;
        }
    }

    public void UnstackItem()
    {
        Inventory.itemBuffer = currentItem;
        Inventory.quantityItemHolding = 1;
        Inventory.holdingItem = true;
        inv.itemBufferImage.enabled = true;
        quantity--;
    }

    public void MouseExit()
    {
        inv.statsPanel.SetActive(false);
        inv.canPreviewItem = false;
    }
}
