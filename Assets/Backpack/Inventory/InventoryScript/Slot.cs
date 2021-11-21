using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Item slotItem;
    public Image slotImage;
    public Sprite slotBigImage;
    public string slotInfo;

    public GameObject itemInSlot;

    public void ItemOnClicked()
    {
    	InventoryManager.UpdateItemInfo(slotInfo);
    }

    public void SetupSlot(Item item)
    {
    	if( item==null )
    	{
    		itemInSlot.SetActive(false);
    		return;
    	}
        slotItem = item;
    	slotImage.sprite = item.itemImage;
    	slotInfo = item.itemInfo;
        slotBigImage = item.itemBigImage;
    }
}
