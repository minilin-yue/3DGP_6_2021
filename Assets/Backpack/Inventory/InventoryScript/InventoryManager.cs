using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    static InventoryManager instance;

    public Inventory myBag;
    public GameObject slotGrid;
    public Image itemBigImage;
    public Text itemInformation;

    public GameObject emptySlot;
    public List<GameObject> slots = new List<GameObject>();

    private int idx = 0;

    void Start()
    {
    	if( instance!=null )
    		Destroy(this);
    	instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            int i = idx + 1;
            i = Mathf.Min(i, instance.myBag.itemList.Count - 1);
            setActiveItem(i);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            int i = idx - 1;
            i = Mathf.Max(i, 0);
            setActiveItem(i);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            int i = idx - 5;
            i = Mathf.Max(i, 0);
            setActiveItem(i);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            int i = idx + 5;
            i = Mathf.Min(i, instance.myBag.itemList.Count - 1);
            setActiveItem(i);
        }
    }
    public static void setActiveItem(int i)
    {
        instance.slots[instance.idx].transform.GetChild(0).gameObject.SetActive(false);
        instance.slots[i].transform.GetChild(0).gameObject.SetActive(true);
        UpdateItemInfo(instance.slots[i].GetComponent<Slot>().slotInfo);
        UpdateItemImage(instance.slots[i].GetComponent<Slot>().slotBigImage);
        instance.idx = i;
    }
    public static void UpdateItemInfo(string itemDescription)
	{
		instance.itemInformation.text = itemDescription;
	}
    public static void UpdateItemImage(Sprite image)
    {
        instance.itemBigImage.sprite = image;
    }

    //public static void CreateNewItem(Item item)
    //{
    //    Slot newItem = Instantiate(instance.slotPrefab, instance.slotGrid.transform.position, Quaternion.identity);
    //    newItem.gameObject.transform.SetParent(instance.slotGrid.transform);
    //    newItem.gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
    //    newItem.SetupSlot(item);
    //}
    public static void RefreshItem()
    {
    	for( int i=0; i<instance.slotGrid.transform.childCount; i++ )
    	{
    		if( instance.transform.childCount==0 )
    			break;
    		Destroy(instance.slotGrid.transform.GetChild(i).gameObject);
    		instance.slots.Clear();
    	}

    	for( int i=0; i<instance.myBag.itemList.Count; i++ )
    	{
    		instance.slots.Add(Instantiate(instance.emptySlot));
    		instance.slots[i].transform.SetParent(instance.slotGrid.transform);
            instance.slots[i].transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            instance.slots[i].GetComponent<Slot>().SetupSlot(instance.myBag.itemList[i]);
    	}
        if (instance.myBag.itemList.Count > 0) setActiveItem(0);
    }


}
