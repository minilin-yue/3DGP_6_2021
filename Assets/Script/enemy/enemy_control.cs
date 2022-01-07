using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_control : MonoBehaviour
{
    public Animator animator;
    Vector3 now_pos;
    public int rand;
    Rigidbody rg;
    public float speed;
    int step;
    float direction;
    public bool hit;
    public Transform player;
    float Distance = 15.0f;
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
        timer = 0.5f;
    }
    // Update is called once per frame
    
    void FixedUpdate()
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
            //voice.Play(0);//dog_roar
            voice.Play(1);//dizzy
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
            voice.Play(0);//dog_roar
            rg.velocity = Vector3.zero;
            timer = 0;
            hit = false;
            counter = 0.5f;
            return;
        }

        animator.SetBool("diz", false);
        animator.SetBool("hit", false);
        animator.SetBool("walk", true);
        timer = counter;
        if(Vector3.Distance(player.position,this.transform.position) < Distance)
        {
            if(Vector3.Distance(player.position, this.transform.position)<3)
                animator.SetBool("attack", true);
            else
                animator.SetBool("attack", false);
            this.transform.LookAt(new Vector3(player.position.x,this.transform.position.y, player.position.z));
            rg.velocity = (this.transform.forward) * speed  + Vector3.down*3;
            return;
        }
        animator.SetBool("attack", false);
        if (step == rand)
        {
            direction = Random.Range(0, 360);
            rand = Random.Range(70, 100);
            step = 0;
        }
        transform.rotation = Quaternion.Euler(0, direction, 0);
        rg.velocity = (this.transform.forward) * speed  + Vector3.down*3;
        step++;
        //Debug.Log(rg.velocity);
    }
}
