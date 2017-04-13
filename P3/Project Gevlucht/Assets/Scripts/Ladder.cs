using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ladder : MonoBehaviour
{

    public UIManager uim;
    public Quest01 quest01;
    public Quest02 quest02;

    public GameObject player;

    public bool canLoad;

    public void OnTriggerStay(Collider col)
    {
        if (quest02.gotHammer)
        {
            uim.triggerPanelText.text = "Press E to repair ship";
            uim.triggerPanel.SetActive(true);
        }

        if (quest01.quest1Ladder)
        {
            uim.triggerPanelText.text = "Press E to fuel ship";
            uim.triggerPanel.SetActive(true);
        }

        if (quest02.gotHammer && Input.GetKeyDown(KeyCode.E) || quest01.quest1Ladder && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Load());
        }
    }

    public void OnTriggerExit(Collider col)
    {
        uim.triggerPanel.SetActive(false);
    }

    public IEnumerator Load()
    {
        //loadbarPanel.SetActive(true);
        player.SetActive(false);
        quest02.quest02Active = false;
        uim.triggerPanel.SetActive(false);

        for (float f = uim.loadbarFill.fillAmount; f < 1; f += (Time.deltaTime / 5))
        {
            uim.loadbarFill.fillAmount += (Time.deltaTime / 5);
            yield return null;
        }

        if (uim.loadbarFill.fillAmount >= 1)
        {
            player.SetActive(true);
            uim.loadbarFill.fillAmount = 0;
            //loadbarPanel.SetActive(false);

            if (quest01.quest1Ladder)
            {
                quest01.QuestComplete();
            }

            if (quest02.gotHammer)
            {
                quest02.QuestComplete();
            }
        }
    }
}
