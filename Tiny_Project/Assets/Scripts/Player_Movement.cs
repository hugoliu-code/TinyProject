using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    /*
     * Basic player testing script for MOVEMENT ONLY
     * Other player attributes and mechanics will be on other scripts attached to the player object in some way
     */
    Rigidbody2D rb;
    
    [Header("Attributes")]
    [SerializeField] float speed;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        Vector2 direction = new Vector2(0, 0);


        if (Input.GetKey(KeyCode.W))
        {
            direction.y = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            direction.x = -1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction.y = -1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            direction.x = 1;
        }
        float appliedSpeed = speed * Time.deltaTime * 100;
        if(appliedSpeed > 100)
        {
            //Throttle speed to 0 when Time.deltaTime is unusually high
            return;
        }
        rb.velocity = direction.normalized * appliedSpeed; //Scaled for framerate and scaled by 100 to make testing easier
    }
}
