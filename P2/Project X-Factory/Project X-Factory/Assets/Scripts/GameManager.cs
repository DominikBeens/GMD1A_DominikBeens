using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Animator animator;

    public GameObject player;
    public GameObject spawn;

    void Start ()
    {
        StartCoroutine(Startgame());
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update ()
    {
		
	}

    public IEnumerator Startgame()
    {
        animator.SetBool("Start Game", true);
        yield return new WaitForSeconds(2f);
        animator.SetBool("Start Game", false);
        animator.SetBool("Start Game 2", true);
        yield return new WaitForSeconds(5.15f);
        animator.SetBool("Start Game 2", false);
    }
}
