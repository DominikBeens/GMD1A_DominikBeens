using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public GameManager gm;
    public UIManager uim;

    public float health = 100;
    public float water = 100;
    public float hunger = 100;

    void Start()
    {
        StartRoutines();
    }

    void Update()
    {
        if (water <= 50 && hunger <= 50 || water <= 15 || hunger <= 15)
        {
            StartCoroutine(Health(health));
        }
        else
        {
            StopCoroutine(Health(health));
        }
    }

    public IEnumerator Health(float f)
    {
        for (float ff = f; ff > 0; ff -= (Time.deltaTime))
        {
            health = ff;
            uim.healthFill.fillAmount = health / 100;
            yield return null;

            if (ff <= 0.1f)
            {
                ff = 0;
                health = 0;
                Dead();
            }
        }
    }

    public IEnumerator Water(float f)
    {
        for (float ff = f; ff > 0; ff -= (Time.deltaTime / 1.2f))
        {
            water = ff;
            uim.waterFill.fillAmount = water / 100;
            yield return null;

            if (ff <= 0.1f)
            {
                ff = 0;
                water = 0;
            }
        }
    }

    public IEnumerator Hunger(float f)
    {
        for (float ff = f; ff > 0; ff -= (Time.deltaTime / 1.5f))
        {
            hunger = ff;
            uim.hungerFill.fillAmount = hunger / 100;
            yield return null;

            if (ff <= 0.1f)
            {
                ff = 0;
                hunger = 0;
            }
        }
    }

    public void StartRoutines()
    {
        StartCoroutine(Water(water));
        StartCoroutine(Hunger(hunger));
    }

    public void Dead()
    {
        StopAllCoroutines();
        uim.gameOverText.text = "You did not maintain your hunger and thirst good enough and died because your health reached zero.";
        gm.GameOverTrigger();
    }
}
