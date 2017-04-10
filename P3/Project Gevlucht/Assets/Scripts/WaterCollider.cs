using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCollider : MonoBehaviour
{

    public GameManager gm;
    public UIManager uim;

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            uim.gameOverText.text = "You jumped off the boat and drowned. \nYour story ends here.";
            gm.GameOverTrigger();        
        }
    }
}
