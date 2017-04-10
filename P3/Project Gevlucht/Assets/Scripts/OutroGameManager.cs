using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OutroGameManager : MonoBehaviour
{

    public List<string> storyT01List = new List<string>();
    public List<string> storyT02List = new List<string>();
    public Text storyText;
    public Text skipText;

    public Text restartGameButtonText;
    public Text quitGameButtonText;

    void Start()
    {
        if (ConversationManager.conversationEnding02)
        {
            storyT01List = storyT02List;
        }

        StartCoroutine(StoryLoop());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Intro");
        }
    }

    public IEnumerator StoryLoop()
    {
        storyText.color = new Color(storyText.color.r, storyText.color.g, storyText.color.b, 0);
        restartGameButtonText.color = new Color(restartGameButtonText.color.r, restartGameButtonText.color.g, restartGameButtonText.color.b, 0);
        quitGameButtonText.color = new Color(quitGameButtonText.color.r, quitGameButtonText.color.g, quitGameButtonText.color.b, 0);

        for (int i = 0; i < storyT01List.Count; i++)
        {
            if (i == storyT01List.Count - 1)
            {
                storyText.text = storyT01List[storyT01List.Count - 1];
                storyText.fontSize = 30;

                while (storyText.color.a < 1.0f)
                {
                    storyText.color = new Color(storyText.color.r, storyText.color.g, storyText.color.b, storyText.color.a + (Time.deltaTime));
                    skipText.color = new Color(skipText.color.r, skipText.color.g, skipText.color.b, skipText.color.a - (Time.deltaTime * 1.5f));
                    yield return null;
                }

                yield return new WaitForSeconds(1);

                while (restartGameButtonText.color.a < 1.0f)
                {
                    restartGameButtonText.color = new Color(restartGameButtonText.color.r, restartGameButtonText.color.g, restartGameButtonText.color.b, restartGameButtonText.color.a + (Time.deltaTime));
                    quitGameButtonText.color = new Color(quitGameButtonText.color.r, quitGameButtonText.color.g, quitGameButtonText.color.b, quitGameButtonText.color.a + (Time.deltaTime));
                    yield return null;
                }
            }
            else
            {
                storyText.text = storyT01List[i];
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
        }
    }

    public IEnumerator WaitForInput()
    {
        while (!Input.GetButton("Jump"))
        {
            yield return null;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Intro");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
