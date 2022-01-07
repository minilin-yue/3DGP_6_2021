using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pizza_spwan : MonoBehaviour
{
    // Start is called before the first frame update
    public bool spwan = false;
    public GameObject pizza;
    public GameObject target;
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (spwan)
        {
            spwan = false;
            GameObject piz = Instantiate(pizza, this.transform);
            piz.transform.position = new Vector3(target.transform.position.x, 0.1f, target.transform.position.z);
        }
    }
}
