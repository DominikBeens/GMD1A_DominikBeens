using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Nexus : MonoBehaviour
{

    public int maxHealth = 100;
    public static int curHealth;

    public GameObject nexus;

    public GameObject scorePanel;
    public GameObject winPanel;
    public Text winScore;

    public Image healthbar;

    public ParticleSystem deathBlink;
    public ParticleSystem deathParticle;

    void Start ()   //het paneel waarmee wordt aangegeven dat je hebt gewonnen is inactief, de levens van de nexus wordt op 100 gezet en de particles die bij de dood van de nexus horen worden gepauseerd
    {
        winPanel.SetActive(false);
        curHealth = 100;
        deathBlink.Pause();
        deathParticle.Pause();
    }
	
	void Update ()  //als de levens van de nexus 0 zijn word de collider inactief en worden de particles afgespeeld
    {
        if (curHealth == 0)
        {
            nexus.GetComponent<Collider>().enabled = false;
            deathBlink.Play();
            deathParticle.Play();
        }

        if (curHealth == 0 && PinballScoreUpdate.pinballs == 0)    //als de levens van de nexus 0 zijn en er geen pinballs meer over zijn, wordt het paneel dat aangeeft dat je hebt gewonnen geactiveerd en het score paneel wordt inactief
        {
            scorePanel.SetActive(false);
            winPanel.SetActive(true);
            winScore.text = "" + BumperScoreUpdate.score;
            Time.timeScale = 0;                                     //ook wordt de tijd weer stop gezet

            AudioManager.victory.Play();
        }

    }

    void OnCollisionEnter(Collision pinball)    //als de pinball collide met de collider van de nexus worden zijn levens met 25 verminderd en omdat de nexus 100 levens heeft wordt de healthbar ook met een kwart verminderd
    {
        if (pinball.gameObject.tag == "Pinball")
        {
            curHealth -= 25;
            healthbar.fillAmount -= 0.25f;
        }
    }
}
