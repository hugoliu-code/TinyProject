using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] AttackData attackData;
    [SerializeField] float bulletSpeed = 10;
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




        GameObject bullet = Instantiate(projectile, transform.position, Quaternion.Euler(0, 0, 0));
        bullet.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;
        bullet.GetComponent<Bullet_Script>().attackData = attackData;
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            Shoot();

        }
    }
}