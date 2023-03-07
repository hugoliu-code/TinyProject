using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp_Manager : MonoBehaviour
{
    // Singleton
    public static Exp_Manager Instance { get; private set; }

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
    public Exp GenerateExp(int value, Vector3 position)
    {
        //After pulling the exp from the pool, set its proper position and value
        GameObject exp = Pool_Manager.Instance.RequestExp();
        exp.transform.position = position;
        exp.GetComponent<Exp>().Initialize(value);
        return exp.GetComponent<Exp>();
    }
}
