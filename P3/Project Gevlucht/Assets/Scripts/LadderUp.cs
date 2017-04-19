using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderUp : MonoBehaviour
{

    public UIManager uim;

    public GameObject player;

    public GameObject ladderUpPos;

    public void OnTriggerStay(Collider col)
    {
        uim.triggerPanelText.text = "Press E to go up";
        uim.triggerPanel.SetActive(true);

        if (Input.GetKeyDown(KeyCode.E))
        {
            uim.triggerPanel.SetActive(false);
            StartCoroutine(MovePlayer());
        }
    }

    public void OnTriggerExit(Collider col)
    {
        uim.triggerPanel.SetActive(false);
    }

    public IEnumerator MovePlayer()
    {
        uim.fadeOverlay.canvasRenderer.SetAlpha(0.01f);
        uim.fadeOverlay.CrossFadeAlpha(1f, 0.5f, false);

        yield return new WaitForSeconds(0.5f);

        player.transform.position = ladderUpPos.transform.position;

        uim.fadeOverlay.CrossFadeAlpha(0f, 0.5f, false);

        yield return new WaitForSeconds(0.5f);
    }
}
