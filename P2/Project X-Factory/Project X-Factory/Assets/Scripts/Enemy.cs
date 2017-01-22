using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public GameObject uimObject;
    public UI_Manager uim;

    public int currentHealth = 100;

    private UnityEngine.AI.NavMeshAgent navMesh;

    public GameObject target;

    public PlayerStats playerStats;
    public EnemySpawner enemySpawner;
    public GameObject enemySpawnerEmpty;

    public bool canAttack;

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            enemySpawner.enemyAmount -= 1;
            Destroy(gameObject);
        }
    }

    void Start()
    {
        navMesh = GetComponent<UnityEngine.AI.NavMeshAgent>();
        canAttack = true;

        target = GameObject.FindWithTag("Player");
        playerStats = target.GetComponent<PlayerStats>();

        enemySpawnerEmpty = GameObject.FindWithTag("EnemySpawner");
        enemySpawner = enemySpawnerEmpty.GetComponent<EnemySpawner>();

        uimObject = GameObject.Find("UI_Manager");
        uim = uimObject.GetComponent<UI_Manager>();

    }

    void Update()
    {
        navMesh.destination = target.transform.position;

        if (navMesh.remainingDistance <= navMesh.stoppingDistance && !navMesh.pathPending && canAttack == true) 
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        canAttack = false;
        yield return new WaitForSeconds(0.5f);
        playerStats.health -= 10;
        uim.healthFill.fillAmount -= 0.1f;
        yield return new WaitForSeconds(1f);
        canAttack = true;
    }
}