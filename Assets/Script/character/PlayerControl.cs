using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    /// <summary>
    /// we can use this to access current plauer
    /// </summary>
    public static PlayerControl cPlayer;

    private void Awake()
    {
        cPlayer = this;
        Debug.Log("current player name = " + this.gameObject.name);
    }

    public UnityEngine.CharacterController controller;
    [SerializeField]
    KeySetting playerKey;

    [Header("移動相關參數")]
    public float speed = 5;

    [Header("跳躍相關參數")]
    public float gravity = -9.18f;
    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float groundDistance = 3.0f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded {
        get {
            Vector3 start = groundCheck.position;
            Vector3 end = new Vector3(start.x, start.y - groundDistance,start.z);
            if (Physics.Linecast(start, end, groundMask))
                return true;
            else
                return false; 
        }
    }

    /// <summary>
    /// contains move and jump
    /// </summary>
    private void Movement()
    {
        //isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        if (Input.GetKey("left shift") && isGrounded)
        {
            speed = 10;
        }
        else
        {
            speed = 5;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(playerKey.jump) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void Update()
    {
        Movement();
    }
}
