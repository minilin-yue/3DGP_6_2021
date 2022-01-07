using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_control : MonoBehaviour
{
    public Animator animator;
    public int rand;
    Rigidbody rg;
    public float speed;
    public int step;
    float direction;
    public bool hit;
    float timer;
    public bool diz = false;
    float counter = 0.5f;
    private Voice voice;
    // Start is called before the first frame update
    void Start()
    {
        voice = gameObject.GetComponent<Voice>();
        rg = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        direction = Random.Range(0, 360);
        rand = Random.Range(70, 100);
        step = 0;
        hit = false;
        timer = counter;
    }
    // Update is called once per frame

    void FixedUpdate()
    {
        Vector3 velocity = Vector3.zero;
        if (timer < counter)
        {
            timer += Time.deltaTime;
            return;
        }
        if (diz)
        {
            animator.SetBool("walk", false);
            animator.SetBool("diz", true);
            voice.Play(0);
            rg.velocity = Vector3.zero;
            timer = 0;
            diz = false;
            counter = 5;
            return;
        }
        if (hit)
        {
            animator.SetBool("walk", false);
            animator.SetBool("hit", true);
            voice.Play(0);
            rg.velocity = Vector3.zero;
            timer = 0;
            hit = false;
            counter = 0.5f;
            return;
        }

        animator.SetBool("hit", false);
        animator.SetBool("walk", true);
        animator.SetBool("diz", false);
        timer = counter;
        if (step == rand)
        {
            direction = Random.Range(0, 360);
            rand = Random.Range(70, 100);
            step = 0;
        }
        transform.rotation = Quaternion.Euler(0, direction, 0);
        rg.velocity = (this.transform.forward) * speed + Vector3.down;
        step++;
    }
}
