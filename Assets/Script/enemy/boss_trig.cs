using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_trig : MonoBehaviour
{
    public boss_control boss;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            boss.hit = true;
            Destroy(other.gameObject);
        }
    }
}
