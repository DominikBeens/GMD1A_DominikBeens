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

    public GameObject restartGameButton;
    public GameObject quitGameButton;
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

    public IEnumerator StoryLoop()
    {
        restartGameButton.SetActive(false);
        quitGameButton.SetActive(false);

        storyText.canvasRenderer.SetAlpha(0.01f);
        skipText.canvasRenderer.SetAlpha(0.01f);
        restartGameButtonText.canvasRenderer.SetAlpha(0.01f);
        quitGameButtonText.canvasRenderer.SetAlpha(0.01f);

        for (int i = 0; i < storyT01List.Count; i++)
        {
            if (i == storyT01List.Count - 1)
            {
                storyText.text = storyT01List[storyT01List.Count - 1];
                storyText.fontSize = 30;

                storyText.CrossFadeAlpha(1f, 1.5f, false);
                skipText.CrossFadeAlpha(0f, 1f, false);

                yield return new WaitForSeconds(2);

                restartGameButton.SetActive(true);
                quitGameButton.SetActive(true);
                restartGameButtonText.CrossFadeAlpha(1f, 1f, false);
                quitGameButtonText.CrossFadeAlpha(1f, 1f, false);
            }
            else
            {
                storyText.text = storyT01List[i];
                storyText.fontSize = 25;

                skipText.text = ("Press or hold Space to continue");
                skipText.fontSize = 15;

                storyText.CrossFadeAlpha(1f, 1f, false);
                skipText.CrossFadeAlpha(1f, 1f, false);

                yield return StartCoroutine(WaitForInput());

                storyText.CrossFadeAlpha(0f, 1f, false);

                yield return new WaitForSeconds(1);
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
