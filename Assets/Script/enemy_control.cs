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
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        direction = Random.Range(0, 360);
        rand = Random.Range(70, 100);
        speed = 20;
        step = 0;
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
            rg.velocity = Vector3.zero;
            timer = 0;
            hit = false;
            return;
        }

        animator.SetBool("hit", false);
        animator.SetBool("walk", true);
        timer = 0.5f;
        if(Vector3.Distance(player.position,this.transform.position) < Distance)
        {
            this.transform.LookAt(player.position);
            rg.velocity = (this.transform.forward ) * speed * Time.deltaTime;
            return;
        }
        if (step == rand)
        {
            direction = Random.Range(0, 360);
            rand = Random.Range(70, 100);
            step = 0;
        }
        transform.rotation = Quaternion.Euler(0, direction, 0);
        rg.velocity = (this.transform.forward ) * speed * Time.deltaTime;
        Debug.Log(rg.velocity);
    }
}
