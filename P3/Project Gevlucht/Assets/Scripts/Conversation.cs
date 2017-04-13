using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Conversation : MonoBehaviour
{

    public UIManager uim;
    public ConversationManager cm;

    public bool pressedButtonA;
    public bool pressedButtonB;
    public bool continueConversation;

    public List<string> playerText = new List<string>();
    public List<string> targetText = new List<string>();
    public int listIndex;

    void Start ()
    {
        uim.optionAText.text = playerText[listIndex];
        uim.optionBText.text = playerText[listIndex + 1];
    }

    void Update()
    {
        if (playerText[listIndex] == "")
        {
            uim.conversationButtonA.SetActive(false);
        }
        else
        {
            uim.conversationButtonA.SetActive(true);
        }

        if (playerText[listIndex + 1] == "")
        {
            uim.conversationButtonB.SetActive(false);
        }
        else
        {
            uim.conversationButtonB.SetActive(true);
        }
    }

    public void StartRoutine()
    {
        StartCoroutine(Tekst());
    }

    public IEnumerator Tekst()
    {
        for (int i = 0; i < targetText.Count; i++)
        {
            yield return StartCoroutine(WaitForButtonPress());

            continueConversation = false;

            yield return new WaitForSeconds(2);

            if (pressedButtonA)
            {
                uim.conversationText.text += "\n" + targetText[listIndex];
                pressedButtonA = false;
            }
            else if (pressedButtonB)
            {
                uim.conversationText.text += "\n" + targetText[listIndex + 1];
                pressedButtonB = false;
            }

            yield return null;

            if (listIndex + 2 < targetText.Count - 1)
            {
                listIndex += 2;
                uim.optionAText.text = playerText[listIndex];
                uim.optionBText.text = playerText[listIndex + 1];
                uim.conversationButtons.SetActive(true);
                uim.quitConversationButton.SetActive(true);
            }
            else
            {
                uim.quitConversationButton.SetActive(true);
            }
        }
    }

    public IEnumerator WaitForButtonPress()
    {
        while (!continueConversation)
        {
            yield return null;
        }
    }

    public void AddChosenTextOptionA()
    {
        PressedButtonA();
        uim.conversationText.text = uim.conversationText.text + "\nYou: " + uim.optionAText.text;

        if (listIndex == playerText.Count - 2)
        {
            ConversationManager.conversationEnding01 = true;
        }
    }

    public void AddChosenTextOptionB()
    {
        PressedButtonB();
        uim.conversationText.text = uim.conversationText.text + "\nYou: " + uim.optionBText.text;

        if (listIndex == playerText.Count - 2)
        {
            ConversationManager.conversationEnding02 = true;
        }
    }


    public void PressedButtonA()
    {
        pressedButtonA = true;
        continueConversation = true;
        uim.conversationButtons.SetActive(false);
    }

    public void PressedButtonB()
    {
        pressedButtonB = true;
        continueConversation = true;
        uim.conversationButtons.SetActive(false);
    }

    public void EndConversation()
    {
        StopAllCoroutines();
        cm.conversationAvailable = false;
        uim.phonePanel.SetActive(false);
    }
}
