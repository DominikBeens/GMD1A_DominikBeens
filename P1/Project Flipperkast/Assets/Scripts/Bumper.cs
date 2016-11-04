using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bumper : MonoBehaviour
{

    public GameObject bumper1;
    public GameObject bumper2;

    void Start()
    {
        bumper1.SetActive(true);    //de eerste bumper is actief
        bumper2.SetActive(false);   //de tweede is inactief
    }
    
    public void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "Bumper")     //bij een collision met de bumper wordt de score die in het script BumperScoreUpdate staat met 10 opgeteld
        {
            BumperScoreUpdate.score += 10;

            if (bumper1.activeInHierarchy == true)      //als bumper1 actief is, maak hem dan inactief en maak bumper2 actief
            {
                bumper1.SetActive(false);
                bumper2.SetActive(true);
            }
            else                                        //maak anders bumper1 actief en bumper2 inactief
            {
                bumper1.SetActive(true);
                bumper2.SetActive(false);
            }
        }
    }
}
