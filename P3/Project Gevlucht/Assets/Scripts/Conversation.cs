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
        uim.scrollView.SetActive(true);

        uim.optionAText.text = playerText[listIndex];
        uim.optionBText.text = playerText[listIndex + 1];
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
                uim.conversationText.text += "\nMom: " + targetText[listIndex];
            }
            else if (pressedButtonB)
            {
                uim.conversationText.text += "\nMom: " + targetText[listIndex + 1];
            }

            yield return null;

            listIndex += 2;
            uim.optionAText.text = playerText[listIndex];
            uim.optionBText.text = playerText[listIndex + 1];

            uim.conversationButtons.SetActive(true);
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
        StartCoroutine(PressedButtonA());
        uim.conversationText.text = uim.conversationText.text + "\nYou: " + uim.optionAText.text;

        if (listIndex == playerText.Count - 2)
        {
            ConversationManager.conversationEnding01 = true;
        }
    }

    public void AddChosenTextOptionB()
    {
        StartCoroutine(PressedButtonB());
        uim.conversationText.text = uim.conversationText.text + "\nYou: " + uim.optionBText.text;

        if (listIndex == playerText.Count - 2)
        {
            ConversationManager.conversationEnding02 = true;
        }
    }


    public IEnumerator PressedButtonA()
    {
        pressedButtonA = true;
        continueConversation = true;
        uim.conversationButtons.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        pressedButtonA = false;
    }

    public IEnumerator PressedButtonB()
    {
        pressedButtonB = true;
        continueConversation = true;
        uim.conversationButtons.SetActive(false);
        yield return new WaitForSeconds(2.5f);
        pressedButtonB = false;
    }

    public void EndConversation()
    {
        StopAllCoroutines();
        cm.conversationAvailable = false;
        uim.phonePanel.SetActive(false);
    }
}
