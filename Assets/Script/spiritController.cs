using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spiritController : MonoBehaviour
{
    public GameObject spiritA;
    public GameObject spiritB;
    public GameObject spiritC;
    public GameObject spiritD;

    private bool a = false;
    private bool b = false;
    private bool c = false;
    private bool d = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!a && Input.GetKeyDown(KeyCode.Alpha1)){
            spiritA.SetActive(true);
            a = true;
        }
        if (!b && Input.GetKeyDown(KeyCode.Alpha2)){
            spiritB.SetActive(true);
            b = true;
        }
        if (!c && Input.GetKeyDown(KeyCode.Alpha3)){
            spiritC.SetActive(true);
            c = true;
        }
        if (!d && Input.GetKeyDown(KeyCode.Alpha4)){
            spiritD.SetActive(true);
            d = true;
        }
    }
}
