using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voice : MonoBehaviour
{
    public AudioClip[] list;
    private AudioSource audiosrc;
    public bool isPlaying;

    // Start is called before the first frame update
    void Start()
    {
        audiosrc = GetComponent<AudioSource>();
        isPlaying = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            audiosrc.Stop();
        }
    }
    //public void play(int s, int t)
    //{
    //    while(s < t && !audiosrc.isPlaying)
    //    {
    //        audiosrc.clip = list[s];
    //        audiosrc.Play();
    //        s++;
    //    }
        
    //}
    public void Play(int idx)
    {
        audiosrc.clip = list[idx];
        audiosrc.Play();
        isPlaying = true;
    }

    public void Stop()
    {
        audiosrc.Stop();
        isPlaying = false;
    }
}
