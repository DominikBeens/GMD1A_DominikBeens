using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public UIManager uim;
    public WaveManager wm;

    void Start()
    {
        uim.StartCoroutine(uim.FadeIn());
        wm.StartCountDown();
    }
}
