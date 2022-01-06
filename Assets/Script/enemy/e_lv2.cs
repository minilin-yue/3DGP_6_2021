using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_lv2 : MonoBehaviour
{
    public Animator animator;
    public bool hit;
    float timer;
    public bool diz = false;
    float counter = 0.5f;
    public bool run = true;
    private Voice voice;
    // Start is called before the first frame update
    void Start()
    {
        voice = gameObject.GetComponent<Voice>();
        hit = false;
        timer = counter;
    }
    // Update is called once per frame

    void Update()
    {
        if (timer < counter)
        {
            timer += Time.deltaTime;
            return;
        }
        if (diz)
        {
            animator.SetBool("walk", false);
            animator.SetBool("diz", true);
            voice.Play(1);
            timer = 0;
            diz = false;
            run = false;
            counter = 5;
            return;
        }
        if (hit)
        {
            animator.SetBool("walk", false);
            animator.SetBool("hit", true);
            voice.Play(0);
            timer = 0;
            hit = false;
            counter = 0.5f;
            run = false;
            return;
        }
        run = true;
        timer = counter;
        animator.SetBool("diz", false);
        animator.SetBool("hit", false);
        animator.SetBool("walk", true);
    }
}
