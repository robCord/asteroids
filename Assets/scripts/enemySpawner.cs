using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public List<GameObject> enemies;
    public List<Transform> spawnLocations;
    public int numEnemies;
    public int maxEnemiesSpawned;
    
    public void spawnEnemies()
    {
        int randLocation = Random.Range(0, spawnLocations.Count);
        int randEnemy = Random.Range(0, enemies.Count);
        GameObject spawnedEnemy = Instantiate(enemies[randEnemy], spawnLocations[randLocation].position, spawnLocations[randLocation].rotation);
        gameplay.instance.enemiesSpawned.Add(spawnedEnemy);
        spawnedEnemy.GetComponent<enemy>().spawner = this;

        

    }

    private void Start()
    {
        for (int  i = 0;  i < maxEnemiesSpawned;  i++)
        {
            gameplay.instance.spawner = this;
            spawnEnemies();
        }
    }

}
