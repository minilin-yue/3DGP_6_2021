﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv2_move : MonoBehaviour
{
    Vector3 now_pos;
    public int rand;
    Rigidbody rg;
    public float speed;
    int step;
    float direction;
    public Transform player;
    float Distance = 15.0f;
    float timer;
    public e_lv2 e_Lv2;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        //animator = GetComponent<Animator>();
        direction = Random.Range(0, 360);
        rand = Random.Range(70, 100);
        step = 0;
        timer = 0.5f;
    }
    // Update is called once per frame

    void Update()
    {
        if (!e_Lv2.run)
        {
            rg.velocity = Vector3.zero;
            return;
        }

        timer = 0.6f;
        if (Vector3.Distance(player.position, this.transform.position) < Distance)
        {
            this.transform.LookAt(new Vector3(transform.position.x + transform.position.x - player.position.x, this.transform.position.y, transform.position.z + transform.position.x - player.position.z));
            rg.velocity = (this.transform.forward + Vector3.down) * speed ;
            return;
        }
        if (step == rand)
        {
            direction = Random.Range(0, 360);
            rand = Random.Range(70, 100);
            step = 0;
        }
        transform.rotation = Quaternion.Euler(0, direction, 0);
        rg.velocity = (this.transform.forward + Vector3.down) * speed;
        Debug.Log(rg.velocity);
    }
}
