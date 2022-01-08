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
    public float destoryTime;
    public GameObject hitEffect;
    public Sprite Icon;
    public int initCount;
    public bool recoveryItem = false;
    //待補...
}
