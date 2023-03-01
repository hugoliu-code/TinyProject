using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool_Manager : MonoBehaviour
{
    private List<GameObject> enemyPool;
    [SerializeField] private int defaultPoolSize = 100;
    [Header("Enemy")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform enemyHolderParent;

    void Start()
    {
        enemyPool = new List<GameObject>();
        GenerateEnemies(defaultPoolSize);
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
}
