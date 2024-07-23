using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject powerup;
    public GameObject[] enemies;

    private float zEnemySpawn = 12.0f;
    private float xSpwanRange = 12.0f;
    private float zPowerRange = 5.0f;
    private float ySpwan = 0.75f;

    private float powerupSpawnTime = 5.0f;
    private float enemySpawnTime = 1.0f;
    private float startDelay = 1.0f;

    void Start()
    {
        InvokeRepeating("SpwanEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("spawnPowerup", startDelay, powerupSpawnTime);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpwanEnemy(){

        float randomX = Random.Range(-xSpwanRange, xSpwanRange);
        int randomIndex = Random.Range(0, enemies.Length);
        Vector3 spawnPos = new Vector3(randomX, ySpwan, zEnemySpawn);
        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    }

    void spawnPowerup(){
        float randomX = Random.Range(-xSpwanRange, xSpwanRange);
        float randomz = Random.Range(-zPowerRange, zPowerRange);
        Vector3 spawnPos = new Vector3(randomX, ySpwan, randomz);
        Instantiate(powerup, spawnPos, powerup.gameObject.transform.rotation);
    }
}
