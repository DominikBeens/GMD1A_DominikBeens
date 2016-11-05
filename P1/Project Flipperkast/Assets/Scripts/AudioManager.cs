using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{

    public static AudioSource welcomeRift;
    public static AudioSource victory;
    public static AudioSource defeat;

    public AudioSource welcometest;
    public AudioSource victorytest;
    public AudioSource defeattest;

    void Start ()
    {
        welcomeRift = welcometest;
        victory = victorytest;
        defeat = defeattest;
    }
	
	void Update ()
    {
	
	}
}