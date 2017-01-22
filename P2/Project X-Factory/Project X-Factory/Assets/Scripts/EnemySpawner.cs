using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    public List<GameObject> spawnPoints = new List<GameObject>();
    public int point;

    public GameObject enemy;
    public GameObject spawn;

    public int enemyAmount = 0;
    public int maxEnemyAmount = 15;
    public bool canSpawn = true;

	void Start ()
    {
        point = Random.Range(0, spawnPoints.Count);
    }

    void Update ()
    {
        if (enemyAmount < maxEnemyAmount && canSpawn == true)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy()
    {
        canSpawn = false;
        GameObject enemySpawn = (GameObject)Instantiate(enemy, spawnPoints[point].transform.position, spawnPoints[point].transform.rotation);
        enemyAmount += 1;
        yield return new WaitForSeconds(3);
        point = Random.Range(0, spawnPoints.Count);
        canSpawn = true;
    }
}
