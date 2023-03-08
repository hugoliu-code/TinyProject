using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skill Data", menuName = "Skill Data")]
public class Skill_Data : ScriptableObject
{
    /*
     * Need to store a skill and the skills it needs as a prereq
     * Store its prereq as a string in the format [group of skills] + [skill id]. For example, "sp1" for the first skill in the "sp" (speed) skill group
     * Store THIS skills name
     */
    public string skillName;
    public string prereqName;
}
