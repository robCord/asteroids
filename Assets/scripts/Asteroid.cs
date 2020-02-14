using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : enemy
{
    Vector3 targetPosition;
    public float moveSpeed;

    protected override void begin()
    {
        targetPosition = target.transform.position - transform.position;
        targetPosition = targetPosition.normalized;
        base.begin();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(targetPosition * moveSpeed * Time.deltaTime);
    }
}
