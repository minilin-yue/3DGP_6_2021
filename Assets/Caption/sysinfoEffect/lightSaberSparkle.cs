using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightSaberSparkle : MonoBehaviour
{
    public GameObject sparkle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerAttack"))
        {
            sparkle.SetActive(true);
            Invoke("stop", 2);
        }
    }
    private void stop()
    {
        sparkle.SetActive(false);
    }
}
