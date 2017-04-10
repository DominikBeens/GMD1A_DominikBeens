using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest02 : MonoBehaviour
{

    public UIManager uim;

    public bool quest02Active;
    public bool gotHammer;
    public bool questDescOn;

    public void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            quest02Active = true;
            StartCoroutine(Dialogue("'What was that? I heard something break downstairs.\nBetter find a hammer and go take a look.'", 8));
            questDescOn = true;
        }
    }

    public IEnumerator Dialogue(string s, int i)
    {
        uim.dialogueTextObject.SetActive(true);
        uim.dialogueText.text = "" + s;
        uim.dialogueText.canvasRenderer.SetAlpha(0.01f);
        uim.dialogueText.CrossFadeAlpha(1f, 1f, false);

        yield return new WaitForSeconds(i);

        uim.dialogueText.CrossFadeAlpha(0f, 1f, false);

        yield return new WaitForSeconds(1.0f);

        uim.dialogueTextObject.SetActive(false);

        QuestDescription();
    }

    public void QuestDescription()
    {
        if (questDescOn)
        {
            uim.questDesc.text = "Find a hammer in one of the crates and repair the ship";
            uim.questDescPanel.SetActive(true);
        }
    }

    public void QuestComplete()
    {
        gotHammer = false;
        questDescOn = false;
        uim.questDescPanel.SetActive(false);
        StartCoroutine(Dialogue("'Good, I repaired the ship.\nLet's hope this will hold'", 8));
        quest02Active = false;
    }
}
