using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public static AudioSource welcomeRift;      //een static audiosource omdat ik hem vanuit het CanvasScript aan moet zetten
    public AudioSource welcometest;             //maar omdat hij static is kan ik hem niet in de inspector zien, maar moet ik hem wel aangeven dus heb ik nog een variable gemaakt van dezelfde audiosource
                                                //de audiosource daarin gezet en de static gelijk gezet aan de niet static audiosource, denk niet dat dit de beste manier is
    public AudioSource backgroundMusic;

    void Start ()
    {
        welcomeRift = welcometest;
    }
	
    public void muteSound()
    {
        if (backgroundMusic.isPlaying)      //als je op de button klikt die hieraan is gekoppeld wordt het geluid als het aan staat gepauseert, als het niet aanstaat wordt het afgespeeld
        {
            backgroundMusic.Pause();
        }
        else
        {
            backgroundMusic.Play();
        }
    }
}