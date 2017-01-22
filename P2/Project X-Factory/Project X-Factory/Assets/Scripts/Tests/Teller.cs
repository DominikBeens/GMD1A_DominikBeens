using UnityEngine;
using System.Collections;

public class Teller : MonoBehaviour
{

    public int intEen = 1;
    public int intTwee = 1;
    public int randomNumEen = Random.Range(1, 100);
    public int randomNumTwee = Random.Range(1, 100);
    public int uitkomst;
    public int uiteindelijkeUitkomst;

    void Start()
    {
        uitkomst = IntsOptellen(intEen, intTwee);
        uiteindelijkeUitkomst = GenerateInt(randomNumEen, randomNumTwee)  + IntsOptellen(intEen, intTwee);
    }

    public int IntsOptellen(int intEen, int intTwee)
    {
        int optellen = intEen + intTwee;
        Debug.Log(optellen);
        return optellen;
    }

    public int GenerateInt(int randomNumEen, int randomNumTwee)
    {
        int optellenTwee = randomNumEen + randomNumTwee;
        return optellenTwee;
    }
}