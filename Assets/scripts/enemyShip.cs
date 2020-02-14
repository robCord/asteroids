using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyShip : enemy
{
    Vector3 targetPosition;
    public float moveSpeed;
    public float enemyRotationSpeed;

    protected override void begin()
    {
        base.begin();
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            rotateTowards(); 
        }
        else
        {
            target = gameplay.instance.player.transform;
        }
        transform.Translate(-Vector3.up * moveSpeed * Time.deltaTime);
    }

    void rotateTowards()
    {

        Vector3 direction = target.transform.position - transform.position;
        float zAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 270;
        Quaternion targetLocation = Quaternion.Euler(0, 0, zAngle);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetLocation, enemyRotationSpeed * Time.deltaTime);
    }
}
