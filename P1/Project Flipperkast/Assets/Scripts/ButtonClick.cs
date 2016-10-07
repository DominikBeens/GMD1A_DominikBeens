using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonClick : MonoBehaviour
{

    public Button knop;
    public Text tekst;

    public int score;

	// Use this for initialization
	void Start ()
    {

	}
	
	// Update is called once per frame
	void Update ()
    {
        
	}

    public void Geklikt()
    {
        score = score + 1;
        tekst.text = score.ToString();
    }
}
