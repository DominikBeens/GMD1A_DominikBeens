﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDescriptions : MonoBehaviour
{

    public UIManager uim;

    public Quest02 quest02;

    public bool descriptionsOn;

    public int randomDialogue;

    public void OnTriggerStay(Collider col)
    {
        if (descriptionsOn)
        {
            if (col.gameObject.layer == 8)
            {
                uim.triggerPanelText.text = "Press E to interact";
                uim.triggerPanel.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    if (col.gameObject.tag == "InteractableCrate")
                    {
                        if (quest02.quest02Active)
                        {
                            uim.dialogueTextObject.SetActive(true);
                            StartCoroutine(DialogueFadeIn());
                            quest02.gotHammer = true;
                            uim.dialogueText.text = "'Got it'";
                        }
                        else
                        {
                            uim.dialogueTextObject.SetActive(true);
                            StartCoroutine(DialogueFadeIn());
                            uim.dialogueText.text = "'There's a hammer inside, good to know.'";
                        }
                    }

                    if (col.gameObject.tag == "InteractableCrate2")
                    {
                        uim.dialogueTextObject.SetActive(true);
                        StartCoroutine(DialogueFadeIn());
                        uim.dialogueText.text = "'There's some smelly fisherman stuff in there'";
                    }

                    if (col.gameObject.tag == "InteractableCupboard")
                    {
                        uim.dialogueTextObject.SetActive(true);
                        StartCoroutine(DialogueFadeIn());
                        uim.dialogueText.text = "'Seems like these cupboards are jammed, I can't get them open.'";
                    }

                    if (col.gameObject.tag == "InteractableAnchor")
                    {
                        uim.dialogueTextObject.SetActive(true);
                        StartCoroutine(DialogueFadeIn());
                        uim.dialogueText.text = "'Maybe I'll need that if something happens'";
                    }

                    if (col.gameObject.tag == "InteractableView")
                    {
                        randomDialogue = Random.Range(0, 3);

                        if (randomDialogue == 0)
                        {
                            uim.dialogueTextObject.SetActive(true);
                            StartCoroutine(DialogueFadeIn());
                            uim.dialogueText.text = "'Its hard to believe what has happend in the past few hours..'";
                        }
                        else if (randomDialogue == 1)
                        {
                            uim.dialogueTextObject.SetActive(true);
                            StartCoroutine(DialogueFadeIn());
                            uim.dialogueText.text = "'I hope my parents are doing fine over there..'";
                        }
                        else if (randomDialogue == 2)
                        {
                            uim.dialogueTextObject.SetActive(true);
                            StartCoroutine(DialogueFadeIn());
                            uim.dialogueText.text = "'The view is stunning but I can't help but think about what's going on over there right now.'";
                        }
                    }
                }
            }
        }
    }

    public void OnTriggerExit(Collider col)
    {
        uim.triggerPanel.SetActive(false);
        StartCoroutine(DialogueFadeOut());
    }

    public IEnumerator DialogueFadeIn()
    {
        uim.dialogueText.canvasRenderer.SetAlpha(0.01f);
        uim.dialogueText.CrossFadeAlpha(1f, 1f, false);

        yield return new WaitForSeconds(1.0f);
    }

    public IEnumerator DialogueFadeOut()
    {
        uim.dialogueText.CrossFadeAlpha(0f, 1f, false);

        yield return new WaitForSeconds(1.0f);

        uim.dialogueTextObject.SetActive(false);
    }
}
