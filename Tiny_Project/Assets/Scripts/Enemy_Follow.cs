using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Follow : MonoBehaviour
{
    Transform playerTransform;
    Rigidbody2D rb;
    private float startTime; //Temporary Variable for testing purposes; DeltaTime is inconsistent in the beginning and causes massive speed spikes on load

    [Header("Attributes")]
    [SerializeField] float speed;
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        startTime = Time.time; //Temporary Variable
    }
    void Update()
    {
        if(Time.time > startTime + 2) //Temporrary Condition
            Movement();

    }
    void Movement()
    {
        if (playerTransform.position.x < gameObject.transform.position.x)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        Vector2 direction = (playerTransform.position - transform.position).normalized;
        rb.velocity = direction * speed * Time.deltaTime * 100; //Scaled for framerate and scaled by 100 to make testing easier
    }
}