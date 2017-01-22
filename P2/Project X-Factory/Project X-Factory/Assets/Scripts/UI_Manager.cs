using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Manager : MonoBehaviour
{
    public GameManager gm;
    public GameObject player;

    [Header("Health")]
    public Image healthFill;
    public Text healthText;

    [Header("Weapon Stuff")]
    public GameObject weaponPickupPanel;
    public Text weaponPickupText;
    public Image ammoCount;

    [Header("Fade")]
    public Image fadeImage;

    [Header("Pause Menu")]
    public GameObject pausePanel;

    [Header("Other")]
    public GameObject radioPanel;
    public GameObject gameoverPanel;

    void Start ()
    {

    }

    void Update ()
    {
        Color color = fadeImage.color;
        color.a -= Time.deltaTime * 0.8f;
        fadeImage.color = color;

        if (Input.GetButtonDown("Cancel"))
        {
            Pause();
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Level");
    }

    public void Pause()
    {
        if (pausePanel.activeInHierarchy == false)
        {
            pausePanel.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
            player.GetComponent<PlayerController>().enabled = false;
        }
        else if(pausePanel.activeInHierarchy == true)
        {
            pausePanel.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Time.timeScale = 1;
            player.GetComponent<PlayerController>().enabled = true;
        }
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
