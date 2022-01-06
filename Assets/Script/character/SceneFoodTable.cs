using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// 用於切換不同場景可以丟出的食物
/// </summary>
[CreateAssetMenu(fileName = "foodTable", menuName = "SceneFoodSetting")]
public class SceneFoodTable : ScriptableObject
{
    public FoodSkill[] Skill_Scene1;
    public FoodSkill[] Skill_Scene2;
    public FoodSkill[] Skill_Scene3;
    public FoodSkill[] Skill_Scene4;
}
