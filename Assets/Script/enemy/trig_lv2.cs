using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trig_lv2 : MonoBehaviour
{
    // Start is called before the first frame update
    public e_lv2 enemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            enemy.hit = true;
            Destroy(other.gameObject);
        }
        if (other.CompareTag("food_bullet"))
        {
            enemy.diz = true;
            Destroy(other.gameObject);
        }
    }
}
