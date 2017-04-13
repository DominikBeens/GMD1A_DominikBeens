using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest01 : MonoBehaviour
{

    public UIManager uim;
    public ObjectDescriptions objDesc;

    public GameObject ship;
    public GameObject endOfRoute;
    public bool startShipMove;

    public int fuelAmount;

    public bool quest01Active;
    public bool quest1Ladder;

	void Start ()
    {
        objDesc.descriptionsOn = false;
        quest01Active = true;
        uim.questDescPanel.SetActive(false);
	}
	
	void Update ()
    {
        if (startShipMove)
        {
            ship.transform.position = Vector3.MoveTowards(ship.transform.position, endOfRoute.transform.position, (Time.deltaTime * 6.5f));
        }

        if (quest01Active)
        {
            uim.questDesc.text = "Gather two cans of fuel";
            uim.questDescPanel.SetActive(true);

            if (fuelAmount == 1)
            {
                uim.questDesc.text = "Gather one more can of fuel";
            }
     
            if (fuelAmount == 2)
            {
                uim.questDesc.text = "Now go to the stairs and put the fuel in the engine";
                quest1Ladder = true;
            }    
        }
    }


    public void QuestComplete()
    {
        quest01Active = false;
        uim.questDescPanel.SetActive(false);
        quest1Ladder = false;
        StartCoroutine(Dialogue());
        objDesc.descriptionsOn = true;
        startShipMove = true;
    }

    public IEnumerator Dialogue()
    {
        uim.dialogueTextObject.SetActive(true);
        uim.dialogueText.text = "'Good, I put the fuel in the engine and the ship is sailing.'\n'Let's see what else I can find on this ship.'";
        uim.dialogueText.canvasRenderer.SetAlpha(0.01f);
        uim.dialogueText.CrossFadeAlpha(1f, 1f, false);


        yield return new WaitForSeconds(6);

        uim.dialogueText.CrossFadeAlpha(0f, 1f, false);

        yield return new WaitForSeconds(1);

        uim.dialogueTextObject.SetActive(false);
    }
}
