using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_trig : MonoBehaviour
{
    public boss_control boss;
    int hit_count = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            boss.hit = true;
            Destroy(other.gameObject);
            hit_count++;
        }
        if (other.CompareTag("food_bullet"))
        {
            boss.diz = true;
            Destroy(other.gameObject);
            hit_count++;
        }
    }
    private void Update()
    {
        Debug.Log(hit_count);
    }
}
