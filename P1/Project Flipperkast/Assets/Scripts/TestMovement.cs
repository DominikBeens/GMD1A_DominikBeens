using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Bounce : MonoBehaviour
{
    public int score;
    public Text tekst;
    public Vector3 hor;
    public int speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.S))
            hor.y = -1;


        else if (Input.GetKey(KeyCode.W))
            hor.y = 1;

        else hor.y = 0;

        Vector3 b = hor * speed * Time.deltaTime;

        transform.Translate(b);

    }
    // OnTriggerEnter (collider collision)
    public void OnCollisionEnter(Collision collision)
    {
        score = score + 1;
        tekst.text = score.ToString();

    }
}