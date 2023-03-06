using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Manager : MonoBehaviour
{
    /* This script will take care of
     * Picking up EXP
     * Leveling up the player
     * Prompting the Skill select screen
     * Store Skill trees and all things related (still not properly planned yet)
     * Give values for game scripts to interpret (like if the "speed upgrade" is chosen, this script should have a indicator that the Player_Movement Script can interpret)
     */
    //Serialized for now, for Debugging and Testing reasons
    [SerializeField] private int playerLevel = 0;
    [SerializeField] private int neededExp = 10;
    [SerializeField] private int currentExp = 0;
    public void AddExp(int exp)
    {
        currentExp += exp;
        while(currentExp >= neededExp)
        {
            LevelUp();
            currentExp -= neededExp;
            //Would need some kind of method to update [neededExp]
        }
    }

    private void LevelUp()
    {
        playerLevel++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Exp"))
        {
            currentExp += collision.gameObject.GetComponent<Exp>().GetValue();
            collision.gameObject.SetActive(false);
        }
    }
}
