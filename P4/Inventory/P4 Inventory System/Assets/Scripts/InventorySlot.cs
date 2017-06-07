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

    private void Update()
    {
        if (panelActive)
        {
            statsPanel.transform.position = Input.mousePosition;
        }

        if (Inventory.movingItem)
        {
            Inventory.itemBufferImage.transform.position = Input.mousePosition;
            Inventory.itemBufferImage.sprite = Inventory.itemBuffer.item.itemSprite;
        }

        if (currentItem != null)
        {
            GetComponent<Image>().sprite = currentItem.item.itemSprite;
        }
        else if (currentItem == null)
        {
            GetComponent<Image>().sprite = emptySlotImage;
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
            Inventory.itemHolding = true;
            Inventory.itemBuffer = currentItem;
            Inventory.itemBufferImage.enabled = true;
            Inventory.movingItem = true;

            currentItem = null;

            statsPanel.SetActive(false);
            panelActive = false;

            print("took item from" + gameObject.name);
        }
        else if (Inventory.itemHolding && currentItem == null)
        {
            Inventory.itemHolding = false;
            currentItem = Inventory.itemBuffer;
            Inventory.itemBuffer = null;
            Inventory.movingItem = false;

            Inventory.itemBufferImage.enabled = false;

            print("and put item in" + gameObject.name);
        }
        else if (Inventory.itemHolding && currentItem != null)
        {
            Inventory.itemSwapVar = currentItem;
            currentItem = Inventory.itemBuffer;
            Inventory.itemBuffer = Inventory.itemSwapVar;
        }
    }

    public void MouseExit()
    {
        statsPanel.SetActive(false);
        panelActive = false;
    }
}
