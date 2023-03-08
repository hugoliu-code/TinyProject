using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
public class Hit_Manager : MonoBehaviour
{
    /*
     * This script should be present in every scene with damage or hitting
     * There should be an event here that will broadcast some damage information, as well as WHO is being attacked
     * So, those who subscribe to the event can check if the event pertains to them, and then can use the damage information
     * 
     * There should be a way for other scripts to call the damage event and pass parameters (preferably within a scriptable object)
     */

    public event onHitEventDelegate onHit;
    public delegate void onHitEventDelegate(Attack_Data data);

    // Singleton
    public static Hit_Manager Instance { get; private set; }

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
    public void BroadcastHit(Attack_Data data)
    {
        onHit?.Invoke(data);
    }

}