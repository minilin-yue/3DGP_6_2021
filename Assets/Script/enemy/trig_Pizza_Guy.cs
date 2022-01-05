using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trig_Pizza_Guy : MonoBehaviour
{
    GameObject Pizza_Guy;
    void Start()
    {
        Pizza_Guy = gameObject.transform.GetChild(0).gameObject;

    }
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")||other.CompareTag("food_bullet"))
        {
            gameObject.transform.GetChild(1).gameObject.SetActive(true);

            Pizza_Guy.GetComponent<Animator>().enabled = false;
        }
    }
}
