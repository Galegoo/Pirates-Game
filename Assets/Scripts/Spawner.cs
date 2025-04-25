using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemiesPrefabs;
    float secondsToSpawn;
    float timeToSpawn;
    [SerializeField] GameObject playerShip;

    [SerializeField] GameObject[] enemiesAlive;
    [SerializeField] float minDistanceFromPlayertoSpawnEnemies;

    public float maxX;
    public float minX;
    public float maxY;
    public float minY;
    bool canSpawn = false;


    // Start is called before the first frame update
    void Start()
    {
        secondsToSpawn = PlayerPrefs.GetFloat("EnemiesSpawnRate");
        timeToSpawn = secondsToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (TimerAndEndGameHandler.gameover == false)
        {
            if (timeToSpawn > 0)
                timeToSpawn -= Time.deltaTime;

            if (timeToSpawn <= 0)
                if (!canSpawn)
                    SpawnEnemies();
        }

    }

    void SpawnEnemies()
    {

        enemiesAlive = GameObject.FindGameObjectsWithTag("Enemy");

        int randomNum = Random.Range(0, enemiesPrefabs.Length);
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        Vector3 spawnPos = new Vector3(randomX, randomY, 0f);
        int count = 0;
        if (enemiesAlive.Length > 0)
        {
            foreach (GameObject aliveEnemie in enemiesAlive)
            {

                if (Vector3.Distance(aliveEnemie.transform.position, spawnPos) <= 1)
                {
                    canSpawn = false;

                }
                else if (count >= enemiesAlive.Length - 1)
                {
                    canSpawn = true;

                }
                else
                    count++;
            }


            if (Vector3.Distance(playerShip.transform.position, spawnPos) >= minDistanceFromPlayertoSpawnEnemies)
            {
                if (canSpawn)
                {
                    timeToSpawn = secondsToSpawn;
                    canSpawn = false;
                    Instantiate(enemiesPrefabs[randomNum], spawnPos, Quaternion.identity);
                }
            }
            else
            {
                count = 0;
                canSpawn = false;
            }

        }
        else
        {
            if (Vector3.Distance(playerShip.transform.position, spawnPos) >= minDistanceFromPlayertoSpawnEnemies)
            {
                timeToSpawn = secondsToSpawn;
                canSpawn = false;
                Instantiate(enemiesPrefabs[randomNum], spawnPos, Quaternion.identity);
            }

            else
            {
                count = 0;
                canSpawn = false;
            }
        }
    }

}
