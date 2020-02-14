using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed = 50.0f;
    Transform tf;
    public float timeUntilDestroy;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        Destroy(this.gameObject, timeUntilDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        tf.Translate(Vector3.up * Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        gameplay.instance.spawner.spawnEnemies();
        Destroy(collision.gameObject);
        Destroy(this.gameObject);
    }
}
