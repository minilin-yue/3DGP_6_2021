using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food : MonoBehaviour
{
    GM_level GameManager;
    public bool food1 = false;
    public bool food2 = false;
    public bool food3 = false;
    public bool food4 = false;
    public bool reset = false;
    public int num = 1;
    public bool trigger = false;
    public bool pick = false;
    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GM_level>();
        if (food1)
        {
            GameManager.sfood1 += 1;
        }
        if (food2)
        {
            GameManager.sfood2 += 1;
        }
        if (food3)
        {
            GameManager.sfood3 += 1;
        }
        if (food4)
        {
            GameManager.sfood4 += 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(trigger)
        {
            if (Input.GetMouseButtonDown(1))
            {
                pick = true;
                Debug.Log("Pressed secondary button.");
            }
        }
        
        if (pick == true)
        {
            if(reset)
            {
                gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.GetChild(2).GetComponent<CD_lv2food>().CD_food = true;
            }

            pick = false;
            gameObject.transform.parent.gameObject.SetActive(false);
            if (food1)
            {
                GameManager.pfood1 += num;
                GameManager.sfood1 -= 1;
            }
            if (food2)
            {
                GameManager.pfood2 += num;
                GameManager.sfood2 -= 1;
            }
            if (food3)
            {
                GameManager.pfood3 += num;
                GameManager.sfood3 -= 1;
            }
            if (food4)
            {
                GameManager.pfood4 += num;
                GameManager.sfood4 -= 1;
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            trigger = true;      
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            trigger = false;
        }
    }
}
