using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour
{

    public Entity currentItem;
    public GameObject statsPanel;
    public Text statsText;
    public bool panelActive;
    public Sprite emptySlotImage;
    public int quantity = 1;
    public Text quantityText;

    private void Start()
    {
        quantityText = GetComponentInChildren<Text>();
    }

    private void Update()
    {
        if (panelActive)
        {
            statsPanel.transform.position = Input.mousePosition;
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
    }

    public void MouseOver()
    {
        if (currentItem != null)
        {
            statsText.text = currentItem.item.itemName + "\n" + "Price: " + currentItem.item.itemPrice + "\n" + "Weight: " + currentItem.item.itemWeight;
            statsPanel.SetActive(true);
            panelActive = true;
        }
    }

    public void MouseClick()
    {
        if (!Inventory.itemHolding && currentItem != null)
        {
            if (!Inventory.canUnstack)
            {
                Inventory.itemHolding = true;
                Inventory.itemBuffer = currentItem;
                Inventory.movingItem = true;
                Inventory.itemBufferImage.enabled = true;
                currentItem = null;
                Inventory.quantityItemHolding = quantity;
                quantity = 1;

                statsPanel.SetActive(false);
                panelActive = false;
            }
            else if (Inventory.canUnstack)
            {
                if (currentItem.item.canStack && quantity > 1)
                {
                    Inventory.itemBuffer = currentItem;
                    Inventory.quantityItemHolding = 1;
                    Inventory.itemHolding = true;
                    Inventory.itemBufferImage.enabled = true;
                    Inventory.movingItem = true;
                    quantity--;
                }
            }
        }
        else if (Inventory.itemHolding && currentItem == null)
        {
            Inventory.itemHolding = false;
            currentItem = Inventory.itemBuffer;
            Inventory.itemBuffer = null;
            Inventory.itemBufferImage.enabled = false;
            Inventory.movingItem = false;
            quantity = Inventory.quantityItemHolding;

        }
        else if (Inventory.itemHolding && currentItem != null)
        {
            if (!Inventory.itemBuffer.item.canStack || Inventory.itemBuffer.item.canStack && !currentItem.item.canStack)
            {
                Inventory.itemSwapVar = currentItem;
                Inventory.quantitySwapVar = quantity;
                currentItem = Inventory.itemBuffer;
                quantity = Inventory.quantityItemHolding;
                Inventory.itemBuffer = Inventory.itemSwapVar;
                Inventory.quantityItemHolding = Inventory.quantitySwapVar;
            }
            else if (Inventory.itemBuffer.item.canStack && currentItem.item.canStack)
            {
                Inventory.itemBuffer = null;
                Inventory.itemBufferImage.enabled = false;
                Inventory.movingItem = false;
                Inventory.itemHolding = false;

                if (currentItem.item.canStack && Inventory.quantityItemHolding == 1)
                {
                    quantity++;
                }
                else if (currentItem.item.canStack && Inventory.quantityItemHolding >= 1)
                {
                    quantity += Inventory.quantityItemHolding;
                }
            }
        }
    }

    public void MouseExit()
    {
        statsPanel.SetActive(false);
        panelActive = false;
    }
}
