using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool_Manager : MonoBehaviour
{
    private List<GameObject> enemyPool;
    private List<GameObject> bulletPool;


    [SerializeField] private int defaultPoolSize = 100;
    [Header("Enemy")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform enemyHolderParent;
    


    [Header("Bullet")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletHolderParent;
    // Singleton
    public static Pool_Manager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }
    void Start()
    {
        enemyPool = new List<GameObject>();
        bulletPool = new List<GameObject>();
        GenerateEnemies(defaultPoolSize);
        GenerateBullets(defaultPoolSize);
    }


    List<GameObject> GenerateEnemies(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab, enemyHolderParent);
            enemy.SetActive(false);

            enemyPool.Add(enemy);
        }

        return enemyPool;
    }
    public GameObject RequestEnemy()
    {
        foreach (GameObject enemy in enemyPool)
        {
            if (enemy.activeInHierarchy == false)
            {
                enemy.SetActive(true);
                return enemy;
            }
        }

        GameObject newEnemy = Instantiate(enemyPrefab, enemyHolderParent);
        enemyPool.Add(newEnemy);

        return newEnemy;
    }

    List<GameObject> GenerateBullets(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject bullet = Instantiate(bulletPrefab, bulletHolderParent);
            bullet.SetActive(false);

            bulletPool.Add(bullet);
        }

        return bulletPool;
    }
    public GameObject RequestBullet()
    {
        foreach (GameObject bullet in bulletPool)
        {
            if (bullet.activeInHierarchy == false)
            {
                bullet.SetActive(true);
                return bullet;
            }
        }

        GameObject newBullet = Instantiate(bulletPrefab, bulletHolderParent);
        bulletPool.Add(newBullet);

        return newBullet;
    }
}
