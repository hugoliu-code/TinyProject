using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    /*
     * Script on the exp prefab with helper functions that help it work better with pooling
     */
    private int value = 1;

    private void Start()
    {
        Initialize(value);
    }

    public void Initialize(int value)
    {
        this.value = value;
        //For polish, we could create a function that varies the size of the sprite based on value
    } 

    public int GetValue()
    {
        return value;
    }

}
