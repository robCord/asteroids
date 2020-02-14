using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class enemy : MonoBehaviour
{
    public Transform target;
    public enemySpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        target = gameplay.instance.player.GetComponent<Transform>();
        begin();
    }

    protected virtual void begin()
    {

    }

    public void die()
    {
        gameplay.instance.enemiesSpawned.Remove(this.gameObject);
        spawner.spawnEnemies();
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<inputController>() != null)
        {
            collision.gameObject.GetComponent<inputController>().checkGameOver();
            Destroy(collision.gameObject);
            gameplay.instance.gameWipe();
            
        }
    }
}
