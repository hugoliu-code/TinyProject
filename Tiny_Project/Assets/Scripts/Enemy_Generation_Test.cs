using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Generation_Test : MonoBehaviour
{

    // Test script for spawning large amounts of enemies


    [SerializeField] Pool_Manager poolManager;
    [SerializeField] int spawnNumber = 10;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(SpawnEnemies(spawnNumber));
        }
    }

    IEnumerator SpawnEnemies(int num)
    {
        for (int i = 0; i < num; i++)
        {
            yield return null;
            poolManager.RequestEnemy();
        }
    }
}
