using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterBottle : MonoBehaviour
{

    public UIManager uim;
    public PlayerStats ps;
    public Closet closet;

    public bool canDrink;

    void Start()
    {
        uim = GameObject.FindGameObjectWithTag("UIM").GetComponent<UIManager>();
        ps = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        closet = GameObject.FindGameObjectWithTag("Closet").GetComponent<Closet>();
    }

    void Update()
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

    public void UseWaterBottle()
    {
        if (canDrink)
        {
            ps.StopAllCoroutines();
            ps.water += 35;
            ps.StartRoutines();
            Destroy(gameObject);
            closet.DecreaseWaterBottle();
        }
        else if (canDrink == false)
        {
            uim.dialogueTextObject.SetActive(true);
            StartCoroutine(DialogueFade());
            uim.dialogueText.text = "'I'm not that thirsty at the moment'";
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
