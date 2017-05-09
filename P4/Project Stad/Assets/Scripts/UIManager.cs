using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Fade")]
    public Image fadeOverlay;

    [Header("Inventory")]
    public GameObject inventoryPanel;

    [Header("Pause Menu")]
    public bool gamePaused;
    public bool canPause = true;

    [Header("WaveCountdown")]
    public WaveManager wm;
    public Text waveText;
    public Text countdownText;

    [Header("Ammo")]                        //TEMP
    public Text currentAmmoText;            //TEMP
    public Text totalAmmoText;              //TEMP
    public AttackShuriken attackShurken;    //TEMP

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    if (inventoryPanel.activeInHierarchy == false)
        //    {
        //        inventoryPanel.SetActive(true);
        //    }
        //    else
        //    {
        //        inventoryPanel.SetActive(false);
        //    }
        //}

        currentAmmoText.text = attackShurken.currentAmmo.ToString();    //TEMP
        totalAmmoText.text = attackShurken.totalAmmo.ToString();        //TEMP

        if (wm.canCountDown)
        {
            waveText.text = "Wave " + wm.nextWave + " is starting in";
            countdownText.text = wm.nextWaveCountDown.ToString("0");
        }

        if (Input.GetKeyDown(KeyCode.Escape) && canPause)
        {
            StartCoroutine(PauseGame());
        }
    }

    public IEnumerator FadeIn()
    {
        fadeOverlay.enabled = true;

        fadeOverlay.canvasRenderer.SetAlpha(1.0f);
        fadeOverlay.CrossFadeAlpha(0f, 1f, false);

        yield return new WaitForSeconds(1.0f);

        fadeOverlay.enabled = false;
    }

    public IEnumerator PauseGame()
    {
        if (gamePaused == false)
        {
            gamePaused = true;
            canPause = false;

            fadeOverlay.enabled = true;

            fadeOverlay.canvasRenderer.SetAlpha(0.1f);
            fadeOverlay.CrossFadeAlpha(1f, 1f, false);

            yield return new WaitForSeconds(1.0f);

            Time.timeScale = 0;
            canPause = true;
        }
        else if (gamePaused == true)
        {
            Time.timeScale = 1;
            canPause = false;

            fadeOverlay.enabled = true;

            fadeOverlay.canvasRenderer.SetAlpha(1.0f);
            fadeOverlay.CrossFadeAlpha(0f, 1f, false);

            yield return new WaitForSeconds(1.0f);

            gamePaused = false;
            canPause = true;
        }
    }
}
