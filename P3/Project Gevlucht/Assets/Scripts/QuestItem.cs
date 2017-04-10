using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestItem : MonoBehaviour
{

    public Quest01 quest;

    public GameObject triggerPanel;
    public Text triggerPanelText;

    public void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            triggerPanelText.text = "Press E to pick up fuel";
            triggerPanel.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                quest.fuelAmount++;
                triggerPanel.SetActive(false);
                gameObject.SetActive(false);
            }
        }
    }

    public void OnTriggerExit(Collider col)
    {
        triggerPanel.SetActive(false);
    }
}
