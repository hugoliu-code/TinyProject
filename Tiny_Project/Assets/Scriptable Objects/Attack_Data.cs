using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Attack Data", menuName = "Attack Data")]
public class Attack_Data : ScriptableObject
{
    public GameObject receiver; //The Gameobject attached to the collider that was hit
    public int damage;
}
