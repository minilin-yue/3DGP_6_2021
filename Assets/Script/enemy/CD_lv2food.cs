using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CD_lv2food : MonoBehaviour
{
    public bool CD_food = false;
    public int CD_time = 30;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CD_food)
        {
            CD_food = false;
            Debug.Log("CD_food");
            Invoke("food_reset", CD_time);
        }

    }

    void food_reset()
    {
        gameObject.transform.parent.gameObject.transform.GetChild(1).gameObject.SetActive(true);
    }
}
