using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Closet : MonoBehaviour
{

    public UIManager uim;

    public List<GameObject> waterbottles = new List<GameObject>();
    public List<GameObject> medkits = new List<GameObject>();

    public int waterbottleListIndex;
    public int medkitListIndex;

    public bool canDrink;

    void Start()
    {
        foreach (GameObject g in waterbottles)
        {
            Instantiate(uim.waterbottleButton, uim.layoutGroup.transform.position, uim.layoutGroup.transform.rotation).transform.SetParent(uim.layoutGroup.transform);
        }

        foreach (GameObject g in medkits)
        {
            Instantiate(uim.medkitButton, uim.layoutGroup.transform.position, uim.layoutGroup.transform.rotation).transform.SetParent(uim.layoutGroup.transform);
        }
    }

    public void DecreaseWaterBottle()
    {
        waterbottles[waterbottleListIndex].SetActive(false);
        waterbottleListIndex++;
    }

    public void DecreaseMedkit()
    {
        medkits[medkitListIndex].SetActive(false);
        medkitListIndex++;
    }

    public void OnTriggerEnter(Collider col)
    {
        uim.triggerPanelText.text = "Press E to interact";
        uim.triggerPanel.SetActive(true);
    }

    public void OnTriggerStay(Collider col)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            uim.closetInterface.SetActive(true);
            uim.triggerPanel.SetActive(false);
        }
    }

    public void OnTriggerExit(Collider col)
    {
        uim.triggerPanel.SetActive(false);
        uim.closetInterface.SetActive(false);
    }

    public void CloseInterface()
    {
        uim.closetInterface.SetActive(false);
    }
}