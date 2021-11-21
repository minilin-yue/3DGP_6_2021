using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemForBag : MonoBehaviour
{
    public Item thisItem;
    public Inventory playerInventory;

    //改用box collider
    private void OnTriggerEnter(Collider other)
    {
    	if( other.gameObject.CompareTag("Player") )
    	{
    		AddNewItem(); 
    		Destroy(gameObject);
    	}
    }

    public void AddNewItem()
    {
    	// 如果包包裡面沒有這個物品
    	//if( !playerInventory.itemList.Contains(thisItem) )
    	//{
    		
    	//	for( int i=0; i<playerInventory.itemList.Count; i++ )
    	//	{
    	//		if( playerInventory.itemList[i]==null )
    	//		{
    	//			playerInventory.itemList[i] = thisItem;
    	//			break;
    	//		}
    	//	}
    	//}
        playerInventory.itemList.Add(thisItem);
    	//InventoryManager.CreateNewItem(thisItem);
    	InventoryManager.RefreshItem();
    }
}


