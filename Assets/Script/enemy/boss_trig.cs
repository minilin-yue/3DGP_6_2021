using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_trig : MonoBehaviour
{
    public boss_control boss;
    int hit_count = 0;
    public pizza_spwan piz;
    float timer = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet")&&timer>0)
        {
            timer = -1;
            boss.hit = true;
            Destroy(other.gameObject);
            hit_count++;
        }
        if (other.CompareTag("food_bullet") && timer > 0)
        {
            timer = -1;
            boss.diz = true;
            Destroy(other.gameObject);
            hit_count++;
        }
    }
    private void FixedUpdate()
    {
        timer += Time.deltaTime;
        if(hit_count == 5)
        {
            piz.spwan = true;
            hit_count = 0;
        }
    }
}
