using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_control : MonoBehaviour
{
    public Animator animator;
    Vector3 now_pos;
    public int rand;
    Rigidbody rg;
    float speed;
    int step;
    float direction;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        direction = Random.Range(0, 360);
        rand = Random.Range(70, 100);
        speed = 20;
        step = 0;
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetBool("walk", true);
        if (step == rand)
        {
            direction = Random.Range(0, 360);
            rand = Random.Range(70, 100);
            step = 0;
        }
        transform.rotation = Quaternion.Euler(0, direction, 0);
        rg.velocity = (this.transform.forward)* 50 * Time.deltaTime;
        step++;
    }
}
