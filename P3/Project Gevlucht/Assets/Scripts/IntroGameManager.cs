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
        storyText.color = new Color(storyText.color.r, storyText.color.g, storyText.color.b, 0);
        startGameButtonText.color = new Color(startGameButtonText.color.r, startGameButtonText.color.g, startGameButtonText.color.b, 0);
        quitGameButtonText.color = new Color(quitGameButtonText.color.r, quitGameButtonText.color.g, quitGameButtonText.color.b, 0);

        for (int i = 0; i < storyTList.Count; i++)
        {
            if (i == 0)
            {
                storyText.text = storyTList[0];
                storyText.fontSize = 30;

                while (storyText.color.a < 1.0f)
                {
                    storyText.color = new Color(storyText.color.r, storyText.color.g, storyText.color.b, storyText.color.a + (Time.deltaTime));
                    yield return null;
                }

                yield return new WaitForSeconds(1);

                while (startGameButtonText.color.a < 1.0f)
                {
                    startGameButtonText.color = new Color(startGameButtonText.color.r, startGameButtonText.color.g, startGameButtonText.color.b, startGameButtonText.color.a + (Time.deltaTime));
                    quitGameButtonText.color = new Color(quitGameButtonText.color.r, quitGameButtonText.color.g, quitGameButtonText.color.b, quitGameButtonText.color.a + (Time.deltaTime));
                    yield return null;
                }

                yield return StartCoroutine(WaitForStart());

                while (startGameButtonText.color.a > 0.0f)
                {
                    startGameButtonText.color = new Color(startGameButtonText.color.r, startGameButtonText.color.g, startGameButtonText.color.b, startGameButtonText.color.a - (Time.deltaTime));
                    quitGameButtonText.color = new Color(quitGameButtonText.color.r, quitGameButtonText.color.g, quitGameButtonText.color.b, quitGameButtonText.color.a - (Time.deltaTime));
                    yield return null;
                }

                yield return new WaitForSeconds(1);

                while (storyText.color.a > 0.0f)
                {
                    storyText.color = new Color(storyText.color.r, storyText.color.g, storyText.color.b, storyText.color.a - (Time.deltaTime));
                    yield return null;
                }

                yield return new WaitForSeconds(0.7f);
            }
            else
            {
                storyText.text = storyTList[i];
                storyText.fontSize = 25;

                skipText.text = ("Press or hold Space to continue");
                skipText.fontSize = 15;

                while (storyText.color.a < 1.0f)
                {
                    storyText.color = new Color(storyText.color.r, storyText.color.g, storyText.color.b, storyText.color.a + (Time.deltaTime));
                    yield return null;
                }

                while (skipText.color.a < 1.0f)
                {
                    skipText.color = new Color(skipText.color.r, skipText.color.g, skipText.color.b, skipText.color.a + (Time.deltaTime * 1.5f));
                    yield return null;
                }

                yield return StartCoroutine(WaitForInput());

                while (storyText.color.a > 0.0f)
                {
                    storyText.color = new Color(storyText.color.r, storyText.color.g, storyText.color.b, storyText.color.a - (Time.deltaTime));
                    yield return null;
                }

                yield return new WaitForSeconds(0.7f);
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
