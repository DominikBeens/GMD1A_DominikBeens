using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Pinball : MonoBehaviour
{

    public GameObject pinball;
    public GameObject pinballSpawn;

    public void OnTriggerEnter(Collider collider)   //als de pinball de trigger raakt waar hij af zou moeten gaaan
    {
        if (gameObject.tag == "Pinball")
        {
            pinball.SetActive(false);   //wordt hij inactief
            PinballScoreUpdate.pinballs -= 1;   //en word er van de pinball tekst (de counter) die in het script PinballScoreUpdate staat 1 afgetrekt

            pinball.transform.position = pinballSpawn.transform.position;   //daarna word de pinball naar zijn spawnbase gemoved/geteleport
            pinball.SetActive(true);    //en wordt hij weer actief gezet
        }

        if (PinballScoreUpdate.pinballs == 0)
        {
            pinball.SetActive(false);   //als er geen pinballs meer over zijn blijft de pinball inactief, er komt geen nieuwe
        }
    }
}
