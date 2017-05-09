using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    TestStats stats = new TestStats();

    public GameObject target;
    public bool canAttack = true;
    public Image healthbar;
    public Animator anim;
    public WaveManager wavem;

    private void Start()
    {
        target = GameObject.FindWithTag("Player");
        healthbar = gameObject.GetComponentInChildren<Image>();
        anim = GetComponent<Animator>();

        stats.maxHealth = 100;
        stats.currentHealth = 100;
        stats.attackDamage = 20;
        stats.attackRange = 2;
        stats.moveSpeed = 2;
    }

    private void Update()
    {
        Vector2 targetX = new Vector2(target.transform.position.x, 0);
        //Vector2 positionX = new Vector2(transform.position.x, 0);

        if (Vector2.Distance(transform.position, target.transform.position) > stats.attackRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetX, stats.moveSpeed * Time.deltaTime);
        }

        if (Vector2.Distance(transform.position, target.transform.position) < stats.attackRange)
        {
            if (canAttack)
            {
                Attack();
            }
        }
    }

    public void Attack()
    {
        anim.SetTrigger("Attack");
    }

    public void DealDamage(int damage)
    {
        stats.currentHealth -= damage;
        healthbar.fillAmount -= (float)damage / stats.maxHealth;

        if (stats.currentHealth <= 0)
        {
            Dead();
        }
    }

    public void Dead()
    {
        Destroy(gameObject);
    }

    public void OnDestroy()
    {
        GameObject gameManager = GameObject.FindGameObjectWithTag("Gamemanager");
        if(gameManager != null)
        {
            gameManager.GetComponent<WaveManager>().EndWave();
        }
        
    }
}
