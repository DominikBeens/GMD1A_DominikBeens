using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{

    public List<GameObject> shopInv = new List<GameObject>();
    public GameObject welcomeText;
    public bool inShop;
    public GameObject shopUi;
    public GameObject buttonPrefab;
    public GameObject scrollMenu;
    public GameObject[] buttons;
    public int[] buttonIndexes;
    public GameObject testspawnlocation;
   
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            welcomeText.SetActive(true);
            if (Input.GetButtonDown("e"))
            {
                if (inShop == false)
                {
                    buttons = GameObject.FindGameObjectsWithTag("Shopbutton");
                    inShop = true;
                    shopUi.SetActive(true);
                    CreateButtons();
                }              
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            welcomeText.SetActive(false);
            Destroyshopbuttons();
            shopUi.SetActive(false);
            inShop = false;
        }
    }

    void CreateButtons()
    {
        if (shopUi.activeSelf == true)
        {
            for (int i = 0; i < shopInv.Count; i++)
            {
                Instantiate(buttonPrefab, transform.position, Quaternion.identity).transform.SetParent(scrollMenu.transform, false);

                foreach (Transform child in buttonPrefab.transform)
                {
                    if (child.CompareTag("Shopbuttontext"))
                    {
                        child.GetComponent<Text>().text = shopInv[i].name;
                    }
                }
            }
        }      
    }

    void Destroyshopbuttons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            Destroy(buttons[i]);            
        }
    }

    public void CreateItem()
    {
        
    }
}
