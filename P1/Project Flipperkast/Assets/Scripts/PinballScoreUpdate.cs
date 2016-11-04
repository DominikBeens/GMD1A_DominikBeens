using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PinballScoreUpdate : MonoBehaviour
{

    public Text pinballCounter;
    public static int pinballs;

    public GameObject scorePanel;
    public GameObject endPanel;
    public Text endScore;

    void Start ()   //je begint met 3 pinballs en de tekst de de hoeveelheid pinballs aangeeft wordt ingesteld
    {
	    pinballs = 3;
        pinballCounter.text = "Pinballs Left: " + pinballs;
	}
	
	void Update ()  //als er geen pinballs meer over zijn en de levens van de nexus zijn meer dan 0, dan heb je verloren en wordt de gameover functie geroepen
    {
        pinballCounter.text = "Pinballs Left: " + pinballs;

        if (pinballs == 0 && Nexus.curHealth > 0)
        {
            GameOver();
        }
    }

    public void GameOver()  //tijdens gameover wordt de tijd weer stil gezet, het score paneel inactief en het 'einde paneel' actief
    {
        Time.timeScale = 0;
        scorePanel.SetActive(false);
        endPanel.SetActive(true);
        endScore.text = "" + BumperScoreUpdate.score;   //de score tekst die op het einde paneel staat wordt gelijk gesteld aan de behaalde score

        AudioManager.defeat.Play();
    }
}
