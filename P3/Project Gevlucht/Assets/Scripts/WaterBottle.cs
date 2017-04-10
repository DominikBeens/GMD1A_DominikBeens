using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterBottle : MonoBehaviour
{

    public bool canDrink;

    public GameObject triggerPanel;
    public Text triggerPanelText;

    public GameObject dialogueTextObject;
    public Text dialogueText;

    public PlayerStats ps;
	
	void Update ()
    {
        if (ps.water >= 65)
        {
            canDrink = false;
        }

        if (ps.water < 65)
        {
            canDrink = true;
        }
	}

    public void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            triggerPanelText.text = "Press E to drink water";
            triggerPanel.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E) && canDrink)
            {
                ps.StopAllCoroutines();
                ps.water += 35;
                ps.StartRoutines();
                triggerPanel.SetActive(false);
                gameObject.GetComponent<MeshRenderer>().enabled = false;
                gameObject.GetComponent<Collider>().enabled = false;
            }

            if (Input.GetKeyDown(KeyCode.E) && canDrink == false)
            {
                dialogueTextObject.SetActive(true);
                StartCoroutine(DialogueFade());
                dialogueText.text = "'I'm not that thirsty at the moment'";

            }
        }
    }

    public void OnTriggerExit(Collider col)
    {
        triggerPanel.SetActive(false);
    }

    public IEnumerator DialogueFade()
    {
        while (dialogueText.color.a < 1.0f)
        {
            dialogueText.color = new Color(dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, dialogueText.color.a + (Time.deltaTime / 0.5f));
            yield return null;
        }

        yield return new WaitForSeconds(2);

        while (dialogueText.color.a > 0.0f)
        {
            dialogueText.color = new Color(dialogueText.color.r, dialogueText.color.g, dialogueText.color.b, dialogueText.color.a - (Time.deltaTime / 0.5f));
            yield return null;
        }

        dialogueTextObject.SetActive(false);
    }
}
