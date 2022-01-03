using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class e_lv2 : MonoBehaviour
{
    public Animator animator;
    public bool hit;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        hit = false;
        timer = 0.5f;
    }
    // Update is called once per frame

    void Update()
    {
        Vector3 velocity = Vector3.zero;
        if (timer < 0.5f)
        {
            timer += Time.deltaTime;
            return;
        }
        if (hit)
        {
            animator.SetBool("walk", false);
            animator.SetBool("hit", true);
            timer = 0;
            hit = false;
            return;
        }
        timer = 0.5f;
        animator.SetBool("hit", false);
        animator.SetBool("walk", true);
    }
}
