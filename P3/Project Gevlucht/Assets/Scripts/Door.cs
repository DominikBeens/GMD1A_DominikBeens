using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Door : MonoBehaviour
{

    public UIManager uim;

    public GameObject player;

    public Animator anim;

    public void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            uim.triggerPanelText.text = "Press E to open door";
            uim.triggerPanel.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E))
            {
                StartCoroutine(DoorMove());
            }
        }
    }

    public void OnTriggerExit(Collider col)
    {
        uim.triggerPanel.SetActive(false);
    }

    public IEnumerator DoorMove()
    {
        anim.SetTrigger("DoorOpen");
        yield return new WaitForSeconds(3);
        anim.SetTrigger("DoorClose");
    }
}
