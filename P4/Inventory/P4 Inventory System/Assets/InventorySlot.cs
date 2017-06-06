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
    public bool movingItem;

    public Image itemDragImage;

    private void Update()
    {
        if (panelActive)
        {
            statsPanel.transform.position = Input.mousePosition;
        }

        if (movingItem)
        {
            itemDragImage.transform.position = Input.mousePosition;
        }

        if (currentItem != null)
        {
            GetComponent<Image>().sprite = currentItem.item.itemSprite;
        }
        else if (currentItem == null)
        {
            GetComponent<Image>().sprite = null;
        }
    }

    public void MouseOver()
    {
        print("mouse over inv slot");
        if (currentItem != null)
        {
            statsText.text = currentItem.item.itemName + "\n" + "Price: " + currentItem.item.itemPrice + "\n" + "Weight: " + currentItem.item.itemWeight;
            statsPanel.SetActive(true);
            panelActive = true;
        }
    }

    public void MouseClick()
    {
        print("mouse clicked");
        if (!Inventory.itemHolding && currentItem != null)
        {
            Inventory.itemHolding = true;
            Inventory.itemBuffer = currentItem;

            itemDragImage.sprite = currentItem.item.itemSprite;
            itemDragImage.enabled = true;
            movingItem = true;

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
            movingItem = false;

            itemDragImage.enabled = false;

            print("and put item in" + gameObject.name);
        }
    }

    public void MouseExit()
    {
        print("mouse exited inv slot");
        statsPanel.SetActive(false);
        panelActive = false;
    }
}
