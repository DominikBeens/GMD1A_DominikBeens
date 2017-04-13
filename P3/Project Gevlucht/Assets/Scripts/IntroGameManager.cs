using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class IntroGameManager : MonoBehaviour
{

    public List<string> storyTList = new List<string>();
    public Text storyText;
    public Text skipText;

    public bool startGame;

    public GameObject startGameButton;
    public GameObject quitGameButton;
    public Text startGameButtonText;
    public Text quitGameButtonText;

    void Start ()
    {
        StartCoroutine(StoryLoop());
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Level");
        }
    }

    public IEnumerator StoryLoop()
    {
        startGameButton.SetActive(false);
        quitGameButton.SetActive(false);

        storyText.canvasRenderer.SetAlpha(0.01f);
        skipText.canvasRenderer.SetAlpha(0.01f);
        startGameButtonText.canvasRenderer.SetAlpha(0.01f);
        quitGameButtonText.canvasRenderer.SetAlpha(0.01f);

        for (int i = 0; i < storyTList.Count; i++)
        {
            if (i == 0)
            {
                storyText.text = storyTList[0];
                storyText.fontSize = 30;

                storyText.CrossFadeAlpha(1f, 1.5f, false);

                yield return new WaitForSeconds(2);

                startGameButton.SetActive(true);
                quitGameButton.SetActive(true);
                startGameButtonText.CrossFadeAlpha(1f, 1f, false);
                quitGameButtonText.CrossFadeAlpha(1f, 1f, false);

                yield return StartCoroutine(WaitForStart());

                startGameButtonText.CrossFadeAlpha(0f, 1f, false);
                quitGameButtonText.CrossFadeAlpha(0f, 1f, false);

                yield return new WaitForSeconds(1);

                startGameButton.SetActive(false);
                quitGameButton.SetActive(false);

                storyText.CrossFadeAlpha(0f, 1.5f, false);

                yield return new WaitForSeconds(2);
            }
            else
            {
                storyText.text = storyTList[i];
                storyText.fontSize = 25;

                skipText.text = ("Press or hold Space to continue");
                skipText.fontSize = 15;

                storyText.CrossFadeAlpha(1f, 1f, false);
                skipText.CrossFadeAlpha(1f, 1f, false);

                yield return StartCoroutine(WaitForInput());

                storyText.CrossFadeAlpha(0f, 1f, false);

                yield return new WaitForSeconds(1);
            }

            if(i == storyTList.Count - 1)
            {
                SceneManager.LoadScene("Level");
            }
        }
    }

    public IEnumerator WaitForInput()
    {
        while (!Input.GetButton("Jump"))
        {
            yield return null;
        }
    }

    public IEnumerator WaitForStart()
    {
        while (startGame == false)
        {
            yield return null;
        }
    }

    public void StartGame()
    {
        startGame = true;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
