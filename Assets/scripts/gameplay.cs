using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameplay : MonoBehaviour
{
    public static gameplay instance;
    public List<GameObject> enemiesSpawned;
    public enemySpawner spawner;
    public GameObject player;
    public GameObject playerPrefab;
    public int playerLives;


    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void gameWipe()
    {
        for (int i = 0; i < enemiesSpawned.Count; i++)
        {
            Destroy(enemiesSpawned[i]);
        }

        enemiesSpawned.Clear();

        for (int i = 0; i < spawner.maxEnemiesSpawned; i++)
        {
            spawner.spawnEnemies();
        }
    }



    // Update is called once per frame
    void Update()
    {
        if (player == null && playerLives > 0)
        {
            playerLives--;
            player = Instantiate(playerPrefab);
        }
        else if (playerLives <= 0)
        {
            Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif 
        }
    }
}
