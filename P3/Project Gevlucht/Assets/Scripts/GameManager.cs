using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public UIManager uim;

    public float speed = 0.5f;

    public GameObject player;
    public GameObject playerStatsPanel;
    public GameObject ship;
    public GameObject endOfRoute;

    public bool canPauseGame = true;

    void Start ()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(StartFadeIn());

        uim.fadeOverlay.CrossFadeAlpha(0f, 2f, false);
    }

    void Update()
    {
        if (ship.transform.position == endOfRoute.transform.position)
        {
            StartCoroutine(EndFadeOut());
        }

        if (Input.GetKeyDown(KeyCode.Escape) && canPauseGame == true)
        {
            StartCoroutine(PauseGame());
        }
    }

    public IEnumerator StartFadeIn()
    {
        uim.questDescPanelImage.canvasRenderer.SetAlpha(0.0f);
        uim.questDesc.canvasRenderer.SetAlpha(0.0f);
        uim.fadeOverlay.CrossFadeAlpha(0f, 2f, false);

        yield return new WaitForSeconds(2);

        //uim.questDescPanelImage.canvasRenderer.SetAlpha(0.01f);
        //uim.questDesc.canvasRenderer.SetAlpha(0.01f);
        uim.questDescPanelImage.CrossFadeAlpha(1f, 1f, false);
        uim.questDesc.CrossFadeAlpha(1f, 1f, false);
    }

    public IEnumerator EndFadeOut()
    {
        yield return new WaitForSeconds(5);

        if (uim.questDescPanelImage.isActiveAndEnabled)
        {
            uim.questDescPanelImage.CrossFadeAlpha(0f, 2f, false);
            uim.questDesc.CrossFadeAlpha(0f, 2f, false);

            yield return new WaitForSeconds(2);
        }

        uim.fadeOverlay.CrossFadeAlpha(1f, 2f, false);

        SceneManager.LoadScene("Outro");
    }

    public void GameOverTrigger()
    {
        StartCoroutine(GameOver());
    }

    public IEnumerator GameOver()
    {
        canPauseGame = false;

        playerStatsPanel.SetActive(false);

        uim.fadeOverlay.CrossFadeAlpha(1f, 2f, false);

        if (uim.questDescPanelImage.isActiveAndEnabled)
        {
            uim.questDescPanelImage.CrossFadeAlpha(0f, 2f, false);
            uim.questDesc.CrossFadeAlpha(0f, 2f, false);
        }

        yield return new WaitForSeconds(2.0f);

        player.SetActive(false);

        uim.gameOverTextObject.SetActive(true);
        uim.gameOverText.canvasRenderer.SetAlpha(0.01f);
        uim.gameOverText.CrossFadeAlpha(1f, 1f, false);

        yield return new WaitForSeconds(1.0f);

        uim.restartButton.SetActive(true);
        uim.quitButton.SetActive(true);

        uim.restartGameButtonText.canvasRenderer.SetAlpha(0.01f);
        uim.restartGameButtonText.CrossFadeAlpha(1f, 1f, false);
        uim.quitGameButtonText.canvasRenderer.SetAlpha(0.01f);
        uim.quitGameButtonText.CrossFadeAlpha(1f, 1f, false);
    }

    public IEnumerator PauseGame()
    {
        canPauseGame = false;

        uim.fadeOverlay.CrossFadeAlpha(1f, 1f, false);

        if (uim.questDescPanelImage.isActiveAndEnabled)
        {
            uim.questDescPanelImage.CrossFadeAlpha(0f, 1f, false);
            uim.questDesc.CrossFadeAlpha(0f, 1f, false);
        }

        yield return new WaitForSeconds(1.0f);

        uim.gamePausedTextObject.SetActive(true);
        uim.gamePausedText.canvasRenderer.SetAlpha(0.01f);
        uim.gamePausedText.CrossFadeAlpha(1f, 1f, false);

        yield return new WaitForSeconds(0.5f);

        uim.resumeButton.SetActive(true);
        uim.quitButton.SetActive(true);

        uim.resumeButtonText.canvasRenderer.SetAlpha(0.01f);
        uim.resumeButtonText.CrossFadeAlpha(1f, 1f, false);
        uim.quitGameButtonText.canvasRenderer.SetAlpha(0.01f);
        uim.quitGameButtonText.CrossFadeAlpha(1f, 1f, false);

        yield return new WaitForSeconds(1.5f);

        Time.timeScale = 0;
    }

    public IEnumerator ResumeGame()
    {
        Time.timeScale = 1;

        uim.resumeButtonText.CrossFadeAlpha(0f, 1f, false);
        uim.quitGameButtonText.CrossFadeAlpha(0f, 1f, false);

        yield return new WaitForSeconds(1.0f);

        uim.resumeButton.SetActive(false);
        uim.quitButton.SetActive(false);

        uim.gamePausedText.CrossFadeAlpha(0f, 1f, false);

        yield return new WaitForSeconds(1.0f);

        uim.gamePausedTextObject.SetActive(false);

        uim.fadeOverlay.CrossFadeAlpha(0f, 1f, false);

        yield return new WaitForSeconds(1.0f);

        if (uim.questDescPanelImage.isActiveAndEnabled)
        {
            uim.questDescPanelImage.canvasRenderer.SetAlpha(0.01f);
            uim.questDescPanelImage.CrossFadeAlpha(1f, 1f, false);
            uim.questDesc.canvasRenderer.SetAlpha(0.01f);
            uim.questDesc.CrossFadeAlpha(1f, 1f, false);
        }

        canPauseGame = true;
    }

    public void ResumeGameButton()
    {
        StartCoroutine(ResumeGame());
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}