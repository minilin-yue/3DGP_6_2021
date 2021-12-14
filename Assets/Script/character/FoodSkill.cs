using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "food", menuName = "new_Skill")]
public class FoodSkill : ScriptableObject
{
    public KeyCode key;
    public GameObject pref;
    public int atk;
    //public int coolDownFrame;
    public float coolDownTime;
    public float InitSpeed;
    //待補...
}
