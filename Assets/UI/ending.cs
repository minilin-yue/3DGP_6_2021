using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ending : MonoBehaviour
{
    private Animation ani;
    // Start is called before the first frame update
    void Start()
    {
        ani = gameObject.GetComponent<Animation>();
        AudioSource[] l = GameObject.FindObjectsOfType<AudioSource>();
        for (int i = 0; i < l.Length; i++)
        {
            l[i].Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!ani.isPlaying)
        {
            #if UNITY_EDITOR
            // Application.Quit() does not work in the editor so
            // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
            UnityEditor.EditorApplication.isPlaying = false;
            #else
                     Application.Quit();
            #endif
        }
    }
}
