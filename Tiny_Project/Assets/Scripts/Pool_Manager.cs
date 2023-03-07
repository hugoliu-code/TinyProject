using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool_Manager : MonoBehaviour
{
    private List<GameObject> enemyPool;
    private List<GameObject> bulletPool;
    private List<GameObject> expPool;
 

    [SerializeField] private int defaultPoolSize = 100;
    [Header("Enemy")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform enemyHolderParent;
    


    [Header("Bullet")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletHolderParent;

    [Header("Exp")]
    [SerializeField] private GameObject expPrefab;
    [SerializeField] private Transform expHolderParent;
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
        GenerateEnemies(defaultPoolSize);

        bulletPool = new List<GameObject>();
        GenerateBullets(defaultPoolSize);


        expPool = new List<GameObject>();
        GenerateExp(defaultPoolSize);
    }

    //ENEMIES POOLING =================================================================================

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

    //BULLETS POOLING =================================================================================

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

    //EXP POOLING =================================================================================
    List<GameObject> GenerateExp(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            GameObject exp = Instantiate(expPrefab, expHolderParent);
            exp.SetActive(false);

            expPool.Add(exp);
        }

        return expPool;
    }
    public GameObject RequestExp()
    {
        foreach (GameObject exp in expPool)
        {
            if (exp.activeInHierarchy == false)
            {
                exp.SetActive(true);
                return exp;
            }
        }

        GameObject newExp = Instantiate(expPrefab, expHolderParent);
        expPool.Add(newExp);

        return newExp;
    }
}
