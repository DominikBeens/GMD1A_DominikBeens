using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medkit : MonoBehaviour
{

    public UIManager uim;
    public PlayerStats ps;
    public Closet closet;

    public bool canHeal;

    void Start()
    {
        uim = GameObject.FindGameObjectWithTag("UIM").GetComponent<UIManager>();
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        closet = GameObject.FindGameObjectWithTag("Closet").GetComponent<Closet>();
    }

    void Update()
    {
        if (ps.health >= 80)
        {
            canHeal = false;
        }

        if (ps.health < 80)
        {
            canHeal = true;
        }
    }

    public void UseMedkit()
    {
        if (canHeal)
        {
            ps.StopAllCoroutines();
            ps.health += 20;
            ps.StartRoutines();
            Destroy(gameObject);
            closet.DecreaseMedkit();
        }
        else if (canHeal == false)
        {
            uim.dialogueTextObject.SetActive(true);
            StartCoroutine(DialogueFade());
            uim.dialogueText.text = "'I'm not really hurt at the moment'";
        }
    }

    public IEnumerator DialogueFade()
    {
        uim.dialogueText.canvasRenderer.SetAlpha(0.01f);
        uim.dialogueText.CrossFadeAlpha(1f, 1f, false);

        yield return new WaitForSeconds(2.0f);

        uim.dialogueText.CrossFadeAlpha(0f, 1f, false);

        yield return new WaitForSeconds(1.0f);

        uim.dialogueTextObject.SetActive(false);
    }
}
