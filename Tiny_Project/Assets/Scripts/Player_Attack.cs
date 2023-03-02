using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] AttackData attackData;
    [SerializeField] float bulletSpeed = 10;
    [SerializeField] float attackDelay = 1f;
    [SerializeField] GameObject projectile;
    private void Start()
    {
        StartCoroutine(Attack());
    }

    void Shoot()
    {

        Vector3 worldPosMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        worldPosMouse.z = 0;
        Vector2 direction = worldPosMouse - transform.position;



        //Old System with Instantiate
        //GameObject bullet = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, 0));

        //Pooling System
        GameObject bullet = Pool_Manager.Instance.RequestBullet();
        bullet.transform.position = transform.position;

        //Set the speed, direction, and data
        bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
        bullet.GetComponent<Bullet_Script>().attackData = attackData;
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(attackDelay);
            Shoot();

        }
    }
}