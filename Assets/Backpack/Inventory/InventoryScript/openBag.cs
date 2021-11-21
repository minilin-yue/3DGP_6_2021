using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openBag : MonoBehaviour
{
    public GameObject bag;
    bool isOpen;
    // Start is called before the first frame update
    void Start()
    {
        bag.SetActive(false);
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            if(isOpen){
                bag.SetActive(false);
                isOpen = false;
            }
            else{
                bag.SetActive(true);
                isOpen = true;
            }
        }
    }
}
