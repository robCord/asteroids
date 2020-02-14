using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bounderies : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<enemy>())
        {
            collision.GetComponent<enemy>().die();
        }
        else
        {
            Destroy(collision.gameObject); 
        }
    }

}
