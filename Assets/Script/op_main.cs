using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class op_main : MonoBehaviour
{
    public AudioManager audioManager;
    public GameObject uno;
    public GameObject unoMove;
    public Animator logo;
    public Animator gesture;
    public Animator pcOnly;
    public GameObject vfx;
    public GameObject cam;
    public GameObject seagullSound;
    private bool check = false;//  play sounds

    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    void Update()
    {
        /*
        if (audioManager.gameObject.GetComponent<AudioSource>().clip == null)
        {
            audioManager.Play("wave");
        }
        */
        if (!check)
        {
            audioManager.Play("wave");
            seagullSound.SetActive(true);
            check = true;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            //audioManager.Play("begin");
            logo.SetTrigger("fadeout");
            gesture.SetTrigger("fadeout");
            pcOnly.SetTrigger("fadeout");
            vfx.SetActive(true);
            //Invoke("bgmrecover", 2);
            Invoke("cng", 4);
        }
    }
    void cng()
    {
        unoMove.GetComponent<Animator>().SetTrigger("start");
        uno.SetActive(true);
        Destroy(this.gameObject, 3f);
    }

    void bgmrecover()
    {
        //audioManager.Play("wave");
    }
}

