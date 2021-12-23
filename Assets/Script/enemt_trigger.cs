using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemt_trigger : MonoBehaviour
{
    public enemy_control enemy;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            enemy.hit = true;
            Destroy(other.gameObject);
        }
    }
}
