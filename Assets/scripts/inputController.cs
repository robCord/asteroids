using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputController : MonoBehaviour
{
    public float rotationSpeed;
    public float moveSpeed;
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform firePoint;

    private float shootTimeCurrent;
    public float shootTimeMax;

    Transform tf;

    //public KeyCode pressUp;
    //public KeyCode pressDown;
    //public KeyCode pressLeft;
    //public KeyCode pressRight;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
        gameplay.instance.player = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (checkFireRate() == true)
            {
                Instantiate(bullet, firePoint.position, tf.rotation); 
            }
        }
        //if (Input.GetKeyDown(pressUp))
        //    GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 0);
        //if (Input.GetKeyDown(pressDown))
        //    GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 180);
        //if (Input.GetKeyDown(pressLeft))
        //    GetComponent<Transform>().eulerAngles = new Vector3(0, 0, 90);
        //if (Input.GetKeyDown(pressRight))
        //    GetComponent<Transform>().eulerAngles = new Vector3(0, 0, -90);
        tf.Translate(0,Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime,0);
        tf.Rotate(0, 0, -Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime);
    }

    private bool checkFireRate()
    {
        if (shootTimeCurrent >= 0)
        {
            shootTimeCurrent -= Time.deltaTime.;
            return false;
        }
        else
        {
            shootTimeCurrent = shootTimeMax;
            return true;
        }
    }

    public void checkGameOver()
    {
        //if (gameplay.instance.playerLives <= 0)
        //{
        //    // Game is over
        //}
    }
}
