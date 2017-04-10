using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConversationManager : MonoBehaviour
{

    public UIManager uim;
    public Conversation conversation;

    public bool conversationAvailable = true;

    public static bool conversationEnding01;
    public static bool conversationEnding02;

    public void OnTriggerEnter(Collider col)
    {
        if (conversationAvailable)
        {
            if (col.gameObject.tag == "Player")
            {
                uim.triggerPanelText.text = "Press E to call home";
                uim.triggerPanel.SetActive(true);
            }
        }
    }

    public void OnTriggerStay(Collider col)
    {
        if (conversationAvailable)
        {
            if (col.gameObject.tag == "Player")
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    uim.phonePanel.SetActive(true);
                    conversation.StartRoutine();

                    uim.triggerPanel.SetActive(false);
                }
            }
        }
    }
}
