using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    //public Sound[] sounds;
    //public static AudioManager instance;
    private AudioSource bgm;
    private List<AudioSource> syncList = new List<AudioSource>();
    [System.Serializable]
    public struct sound
    {
        public string name;
        public AudioClip clip;
        [Range(0.0f, 1.0f)]
        public float volume;
        public bool loop;
    }
    public sound[] bgmList;
    // Start is called before the first frame update
    void Awake()
    {
        /*
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        */
   
        //foreach(Sound s in sounds)
        //{
        //    s.source = gameObject.AddComponent<AudioSource>();
        //    s.source.clip = s.clip;

        //    s.source.volume = s.volume;
        //    s.source.pitch = s.pitch;
        //    s.source.loop = s.loop ;
        //}
    }
    private void Start()
    {
        bgm = gameObject.GetComponent<AudioSource>();
    }

    public bool Play(string name)
    {
        //Sound s = Array.Find(sounds, sound => sound.name == name);

        //s.source.Play();
        try
        {
            sound s = Array.Find(bgmList, sound => sound.name == name);
            bgm.clip = s.clip;
            bgm.volume = s.volume;
            bgm.loop = s.loop;
            bgm.Play();
            return true;
        }
        catch(ArgumentNullException e)
        {
            Debug.LogWarning("Sound" + name + "Not Found. " + e);
            return false;
        }        
    }

    public void Stop()
    {
        //Sound s = Array.Find(sounds, sound => sound.name == name);
        //if (s == null)
        //{
        //    Debug.LogWarning("Sound" + name + "Not Found");
        //}
        //s.source.Stop();
        bgm.Stop();
    }
    public void syncPlay(string name)
    {
        
        try
        {
            sound s = Array.Find(bgmList, sound => sound.name == name);
            AudioSource a = gameObject.AddComponent<AudioSource>();
            syncList.Add(a);
            a.clip = s.clip;
            a.volume = s.volume;
            a.loop = s.loop;
            a.Play();
        }
        catch (ArgumentNullException e)
        {
            Debug.LogWarning("Sound" + name + "Not Found. " + e);
        }
    }

    public void syncStop()
    {
        for(int i = 0; i < syncList.Count; i++)
        {
            syncList[i].Stop();
            Destroy(syncList[i]);
        }
        syncList.Clear();
    }
    public void syncStop(string name)
    {
        try
        {
            sound s = Array.Find(bgmList, sound => sound.name == name);
            AudioSource a = syncList.Find(x => x.clip == s.clip);
            a.Stop();
            Destroy(a);
            syncList.Remove(a);
        }
        catch (ArgumentNullException e)
        {
            Debug.LogWarning("Sound" + name + "Not Found. " + e);
        }
    }

}
