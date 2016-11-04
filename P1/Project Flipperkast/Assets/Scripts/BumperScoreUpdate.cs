using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BumperScoreUpdate : MonoBehaviour
{

    public Text scoreCounter;
    public static int score;

	void Start ()
    {
	
	}
	
	void Update ()
    {
        scoreCounter.text = "Score: " + score;  //de score tekst wordt Score: + het aantal punten dat je hebt
    }
}
