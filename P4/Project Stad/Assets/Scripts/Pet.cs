using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pet : MonoBehaviour {
    public List<string> randomSpeech = new List<string>();
    public string saydis;
    public GameObject player;
    public int speechInterval;
    public int fadeInterval;
    public float attackSpeed;
    public int attackDamage;
    public Text speechBubble;
    public bool iscalcing;
    public GameObject targetEnemy;
    public bool attacking;
    public bool givemaxHp;
    public bool giveSpeed;
    public bool giveDef;
    public bool giveWepskill;
    public int skillTogive;
    public float timeTogiveskill;

    // Use this for initialization
    void Start () {
        GiveStats();

    }
	
	// Update is called once per frame
	void Update () {
        if (iscalcing == false)
        {
            StartCoroutine("Saystuff");
        }
       
    }

    IEnumerator Saystuff()
    {
        iscalcing = true;
        yield return new WaitForSeconds(speechInterval);
        int say = Random.Range(0, randomSpeech.Count);
        saydis = randomSpeech[say];
        speechBubble.text = gameObject.name + ":" + saydis;
        yield return new WaitForSeconds(fadeInterval);
        iscalcing = false;
        speechBubble.text = null;

    }

    void Attackrepeat()
    {
        StartCoroutine("Attack");
        
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(attackSpeed);
        if (targetEnemy != null)
        {
            targetEnemy.GetComponent<Stats>().health -= attackDamage;
        }
        
        attacking = false;

    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
           
            if (Physics2D.Raycast(transform.position, other.transform.position, 5))
            {
                if(attacking == false)
                {
                    targetEnemy = other.gameObject;
                    InvokeRepeating("Attackrepeat", attackSpeed, 1F);
                    attacking = true;
                }
               
            }
        }
    }

    public void OnTriggerExit2D()
    {
        CancelInvoke();
        attacking = false;
        targetEnemy = null;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            GiveStats();
            player = other.gameObject;
        }
    }

    public void GiveStats()
    {
       
        if(givemaxHp == true)
        {
            InvokeRepeating("Givhp", timeTogiveskill, 1F);
        }

        if (giveDef == true)
        {
            InvokeRepeating("Givdf", timeTogiveskill, 1F);
        }

        if (giveSpeed == true)
        {
            InvokeRepeating("Givsp", timeTogiveskill, 1F);
        }

        if (giveWepskill == true)
        {
            InvokeRepeating("Givwpsk", timeTogiveskill, 1F);
        }
    }

    void Givhp()
    {
        
        player.GetComponent<Stats>().health += skillTogive;
    }

    void Givdf()
    {
        
        player.GetComponent<Stats>().defense += skillTogive;
    }

    void Givsp()
    {
        
        player.GetComponent<Stats>().speed += skillTogive;
    }

    void Givwpsk()
    {
        
        player.GetComponent<Stats>().weaponskill += skillTogive;
    }
}
