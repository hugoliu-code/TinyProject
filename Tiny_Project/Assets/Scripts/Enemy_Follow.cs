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
    [SerializeField] int health = 10;
    private int maxHealth;
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
        maxHealth = health;
        startTime = Time.time; //Temporary Variable
        Hit_Manager.Instance.onHit += TakeDamage;
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

 
    private void TakeDamage(AttackData data)
    {
        if (data.receiver.Equals(this.gameObject))
        {
            health -= data.damage;
            if(health <= 0)
            {
                ResetStats();
                this.gameObject.SetActive(false);
            }
        }
    }

    void ResetStats()
    {
        //When an enemy dies, we need to prepare it for reuse in the pool
        health = maxHealth;
    }
}