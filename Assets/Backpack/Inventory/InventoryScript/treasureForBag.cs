using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treasureForBag : MonoBehaviour
{
    public Item treasureA;
    public Item treasureB;
    public Item treasureC;
    public Item treasureD;

    public Item itemA;
    public Item itemB;
    public Item itemC;
    public Item itemD;

    public GameObject letterA;
    public GameObject letterB;
    public GameObject letterC;
    public GameObject letterD;

    public GameObject PointLightA;
    public GameObject PointLightB;
    public GameObject PointLightC;
    public GameObject PointLightD;

    public GameObject spiritA;
    public GameObject spiritB;
    public GameObject spiritC;
    public GameObject spiritD;

    public Inventory playerInventory;
    private bool a = false;
    private bool b = false;
    private bool c = false;
    private bool d = false;

    private bool aa = false;
    private bool bb = false;
    private bool cc = false;
    private bool dd = false;

    void Start()
    {

    }

    void Update()
    {
        if (!aa && spiritA.activeSelf)
        {
            letterA.SetActive(false);
            aa = true;
        }
        if (!a && PointLightA.activeSelf)
        {
            AddNewItemA();
            a = true;
        }

        if (!bb && spiritB.activeSelf)
        {
            letterB.SetActive(false);
            bb = true;
        }
        if (!b && PointLightB.activeSelf)
        {
            AddNewItemB();
            b = true;
        }

        if (!cc && spiritC.activeSelf)
        {
            letterC.SetActive(false);
            cc = true;
        }
        if (!c && PointLightC.activeSelf)
        {
            AddNewItemC();
            c = true;
        }

        if (!dd && spiritD.activeSelf)
        {
            letterD.SetActive(false);
            dd = true;
        }
        if (!d && PointLightD.activeSelf)
        {
            AddNewItemD();
            d = true;
        }
        if(a && b && c && d)
        {
            Destroy(gameObject);
        }
    }

    void AddNewItemA()
    {
        playerInventory.itemList.Add(treasureA);
        playerInventory.itemList.Add(itemA);
        InventoryManager.RefreshItem();
    }
    void AddNewItemB()
    {
        playerInventory.itemList.Add(treasureB);
        playerInventory.itemList.Add(itemB);
        InventoryManager.RefreshItem();
    }
    void AddNewItemC()
    {
        playerInventory.itemList.Add(treasureC);
        playerInventory.itemList.Add(itemC);
        InventoryManager.RefreshItem();
    }
    void AddNewItemD()
    {
        playerInventory.itemList.Add(treasureD);
        playerInventory.itemList.Add(itemD);
        InventoryManager.RefreshItem();
    }
}


