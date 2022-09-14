using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private bool canSpawn;
    [SerializeField] private float asteroid_maxSpawnTime;
    [SerializeField] private float asteroid_minSpawnTime;
    private float asteroid_spawnTime;
    private float asteroid_timer = 0;

    [SerializeField] private float powerUp_maxSpawnTime;
    [SerializeField] private float powerUp_minSpawnTime;
    private float powerUp_spawnTime;
    private float powerUp_timer = 0;

    [SerializeField] private float enemy_maxSpawnTime;
    [SerializeField] private float enemy_minSpawnTime;
    private float enemy_spawnTime;
    private float enemy_timer = 0;


    [SerializeField] private GameObject enemySpawner;
    [SerializeField] private GameObject asteroidSpawner;
    [SerializeField] private GameObject powerUpSpawner;

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject asteroidPrefab;


    // Start is called before the first frame update
    void Start()
    {
        asteroid_spawnTime = Random.Range(asteroid_minSpawnTime, asteroid_maxSpawnTime);
        powerUp_spawnTime = Random.Range(powerUp_minSpawnTime, powerUp_maxSpawnTime);
        enemy_spawnTime = Random.Range(enemy_minSpawnTime, enemy_maxSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        AsteroidSpawn();
        PowerUpSpawn();
        EnemySpawn();
    }

    private void AsteroidSpawn() {
        asteroid_timer += Time.deltaTime;
        if (asteroid_timer >= asteroid_spawnTime) {
            asteroid_timer = 0;
            asteroid_spawnTime = Random.Range(asteroid_minSpawnTime, asteroid_maxSpawnTime);
            Instantiate(asteroidPrefab, asteroidSpawner.transform.position, asteroidSpawner.transform.rotation);
        }
    }

    private void PowerUpSpawn()
    {
        powerUp_timer += Time.deltaTime;
        if (powerUp_timer >= powerUp_spawnTime)
        {
            powerUp_timer = 0;
            powerUp_spawnTime = Random.Range(powerUp_minSpawnTime, powerUp_maxSpawnTime);
            Debug.Log("PowerUp just spawned");
        }
    }

    private void EnemySpawn()
    {
        enemy_timer += Time.deltaTime;
        if (enemy_timer >= enemy_spawnTime)
        {
            enemy_timer = 0;
            enemy_spawnTime = Random.Range(enemy_minSpawnTime, enemy_maxSpawnTime);
            Instantiate(enemyPrefab, enemySpawner.transform.position, new Quaternion(0, 0, 180, 0));
        }
    }
}
