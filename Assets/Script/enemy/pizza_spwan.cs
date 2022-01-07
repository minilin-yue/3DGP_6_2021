using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pizza_spwan : MonoBehaviour
{
    public bool sp = false;
    public GameObject pizza;
    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position = target.position;
        if (sp)
        {
            GameObject fall = Instantiate(pizza, this.transform);
            fall.transform.position = fall.transform.position + Vector3.up * 5;
            sp = false;
        }
    }
}
