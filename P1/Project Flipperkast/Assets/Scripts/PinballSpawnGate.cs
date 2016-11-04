using UnityEngine;
using System.Collections;

public class PinballSpawnGate : MonoBehaviour
{

    public Vector3 openPos;     //de coordinaten van de poort als hij open is
    public Vector3 closePos;    //de coordinaten van de poort als hij dicht is
    public GameObject gate;     //de poort als gameobject
	
	void Update ()      //als de middelste muisknop ingedrukt wordt gehouden dan wordt de positie van de poort gelijk gesteld aan de coordinaten van openPos, dus als hij open is 
    {
        if (Input.GetMouseButton(2))
        {
            gate.transform.position = openPos;
        }
        else    //en anders worden de coordinaten gelijk gesteld aan de coordinaten van closePos, dus als hij dicht is
        {
            gate.transform.position = closePos;
        }
	}
}
