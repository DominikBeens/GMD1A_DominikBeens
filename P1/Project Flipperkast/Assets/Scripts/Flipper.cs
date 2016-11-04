using UnityEngine;
using System.Collections;

public class Flipper : MonoBehaviour
{

    public bool activateFlipper;
    public bool deActivateFlipper;
    public float activateTimer = 0f;
    public float deActivateTimer = 0f;
    public GameObject flipperPivot;
    public Rigidbody pinball;
    public string inputButtonName = "Fire1";
    public int rotationUp;
    public int rotationDown;
    public Quaternion startPos;     //de exacte rotatie van de flipper waar hij in het begin van de game op staat

    void Start()
    {
        startPos = flipperPivot.transform.rotation;     //de coordinaten van de start rotatie worden gelijk gesteld aan de rotatie van de flipper op het moment wanneer de game begint
    }

    public void OnCollisionEnter(Collision pinball)     //als de flipper collide met de pinball wordt de pinball met force weggeschoten, maar alleen als er een bepaalde input is geregistreerd
    {  
        if (activateFlipper == true)
        {
            pinball.rigidbody.AddForce(0, 0, 750);
        }  
    }

    void Update ()
    {
        if (Input.GetButtonDown(inputButtonName))       //je kunt de input zelf instellen in de editor, als de ingestelde input word ingedrukt begint de if statement activateFlipper te lopen
        {
            activateFlipper = true;
        }

        if (activateTimer > 0.06f)      //als de timer groter is dan 0.06f dan wordt de if statement activateFlipper niet meer uitgevoerd en wordt de timer weer op 0 gezet
        {
            activateFlipper = false;
            activateTimer = 0f;
        }

        if (activateFlipper)        //hier wordt de flipper om een bepaald punt gedraait met de snelheid die in de editor is bepaald met rotationUp
        {
            transform.RotateAround(transform.position, flipperPivot.transform.forward, rotationUp * Time.deltaTime);
            activateTimer = activateTimer + Time.deltaTime;
        }

        if (Input.GetButtonUp(inputButtonName))     //als de ingestelde input los wordt gelaten dan wordt de if statement deActivateFlipper geactiveerd
        {
            deActivateFlipper = true;
        }

        if (deActivateTimer > 0.06f)        //als de timer groter is dan 0.06f dan wordt de if statement deActivateFlipper niet meer uitgevoerd en wordt de timer weer op 0 gezet
        {
            deActivateFlipper = false;
            deActivateTimer = 0f;
            flipperPivot.transform.rotation = startPos;     //als de flipper klaar is met zijn rotatie terug wordt er nog voor gezorgt dat de rotatie van de flipper gelijk wordt gesteld aan de rotatie die aan het begin van de game werd vastgesteld
                                                            //dit zorgt ervoor dat de flipper altijd op de zelfde plek terug komt na zijn rotatie heen en weer, zonder dit zou de flipper langzaam, of soms ineens, uit zijn baan raken en een andere rotatie krijgen
        }

        if (deActivateFlipper)      //hier wordt de flipper weer om een bepaald punt heen de andere richting op gedraait, die snelheid is weer in de editor bepaald met rotationDown
        {
            transform.RotateAround(transform.position, flipperPivot.transform.forward, rotationDown * Time.deltaTime);
            deActivateTimer = deActivateTimer + Time.deltaTime;
        }
    }
}
