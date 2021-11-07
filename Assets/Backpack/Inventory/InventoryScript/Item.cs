using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/New Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public Sprite itemImage;
    public Sprite itemBigImage;
    // public int itemHeld;// 物品有幾個
    [TextArea]
    public string itemInfo;
    //public bool equip;
}
