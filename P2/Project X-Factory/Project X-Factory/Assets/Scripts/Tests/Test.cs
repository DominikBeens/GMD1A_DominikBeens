using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float exclusiefBedrag;
    public float inclusiefBedrag;

    void Start()
    {
        BTW(exclusiefBedrag);
    }

    float BTW(float bedrag)
    {
        bedrag *= 1.21f;
        inclusiefBedrag = bedrag;
        return bedrag;
    }
}
