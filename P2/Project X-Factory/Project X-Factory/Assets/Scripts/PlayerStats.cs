using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{

    public UI_Manager uim;

    public int health = 100;

    public GameObject player;

	void Start ()
    {
        Time.timeScale = 1;
        uim.gameoverPanel.SetActive(false);
	}
	
	void Update ()
    {
        uim.healthText.text = ("" + health);

        if (health == 0)
        {
            Dead();
        }

	}

    public void Dead()
    {
        uim.gameoverPanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 0;
        player.GetComponent<PlayerController>().enabled = false;
    }
}
