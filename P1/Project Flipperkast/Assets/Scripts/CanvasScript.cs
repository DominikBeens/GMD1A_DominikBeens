using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CanvasScript : MonoBehaviour
{

    public GameObject introPanel;
    public GameObject scorePanel;
    public GameObject endPanel;

	void Start ()
    {
        Time.timeScale = 0;             //de tijd wordt stop gezet zodat er nog niets kan gebeuren terwijl het intro paneel actief is, bijvoorbeeld dat de pinball al vast gaat rollen
        introPanel.SetActive(true);     //alleen het intro paneel is actief, de rest niet
        scorePanel.SetActive(false);
        endPanel.SetActive(false);
	}
    
    public void StartGame()
    {
        Time.timeScale = 1;             //als je op start klikt loopt de tijd gewoon verder en kun je het spel spelen, het intro paneel wordt inactief en het score paneel actief, ook wordt er een audioclip afgespeeld
        introPanel.SetActive(false);
        scorePanel.SetActive(true);

        AudioManager.welcomeRift.Play();
    }

    public void QuitGame()
    {
        Application.Quit();     //het spel wordt afgesloten als je op quit klikt
    }

    public void Retry()
    {
        SceneManager.LoadScene("Scene Flipperkast");    //bij retry wordt de scene opnieuw geladen
        BumperScoreUpdate.score = 0;
    }
}
