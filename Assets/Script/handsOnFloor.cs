using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class handsOnFloor : MonoBehaviour
{
    public GameObject hands;
    private Voice voice;

    // Start is called before the first frame update
    void Start()
    {
        voice = gameObject.GetComponent<Voice>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            voice.Play(0);
            hands.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        voice.Stop();
        hands.SetActive(false);
    }
}
