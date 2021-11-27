using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "key", menuName = "keySettingFile")]
public class KeySetting : ScriptableObject
{
    public KeyCode jump = KeyCode.Space;
    public KeyCode backpack = KeyCode.E;
    public KeyCode[] SkillKey;

}
