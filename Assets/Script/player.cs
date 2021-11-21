using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    bool w, a, s, d;
    bool click;
    float speed, mouse_x, mouse_y;
    float rotate_apeed,jumptime;
    Camera mcam;
    public Vector3 velocity, mouseDir;
    Rigidbody rb;
    RaycastHit hit;
    public LayerMask mask;
    bool jump;
    LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        mcam = Camera.main;
        speed = 5f;
        rotate_apeed = 2f;
        rb = GetComponent<Rigidbody>();
        line = GetComponent<LineRenderer>();
        Cursor.lockState = CursorLockMode.Locked;
        jump = false;
    }

    // Update is called once per frame
    void Update()
    {
        w = Input.GetKey(KeyCode.W);
        a = Input.GetKey(KeyCode.A);
        s = Input.GetKey(KeyCode.S);
        d = Input.GetKey(KeyCode.D);
        if (Input.GetMouseButtonDown(0))
            click = true;

        if (Input.GetKeyDown(KeyCode.Space)&&!jump)
        {
            jump = true;
            rb.velocity = new Vector3(0, 5.5f, 0);
        }

        if(jumptime <=0 )
        {
            jump = false;
            jumptime = 2f;
        }
        jumptime -= Time.deltaTime;
        mouse_x = Input.GetAxis("Mouse X");
        mouse_y = Input.GetAxis("Mouse Y");

        mouseDir += new Vector3(-mouse_y, mouse_x, 0);

        mouseDir.x = Mathf.Clamp(mouseDir.x, -25f, 25f);
    }
    private void FixedUpdate()
    {
        velocity = Vector3.zero;
        if (w)
            velocity += this.transform.forward * speed;
        if (a)
            velocity += this.transform.right * speed * -1;
        if (s)
            velocity += this.transform.forward * speed * -1;
        if (d)
            velocity += this.transform.right * speed;
        
        velocity.y = rb.velocity.y;
        rb.velocity = velocity;

        if (click)
        {
            click = false;
            StartCoroutine(ShotEffect());
            if (Physics.Raycast(this.transform.position, mcam.transform.forward, out hit, 250f, mask))
            {
                //hit.transform.GetComponent<HP>().hpnow -= 20;
                Debug.Log(hit.transform.name);
            }
            //Debug.DrawLine(this.transform.position, this.transform.position + mcam.transform.forward * 100f);

        }

        this.transform.localEulerAngles = Vector3.up * mouseDir.y * rotate_apeed;
        mcam.transform.localEulerAngles = Vector3.right * mouseDir.x * rotate_apeed;
    }
    private IEnumerator ShotEffect()
    {
        line.SetPosition(0, this.transform.position + this.transform.forward*0.01f);
        line.SetPosition(1, this.transform.position + mcam.transform.forward * 250f);
        Debug.Log("fire");
        line.enabled = true;

        yield return new WaitForSeconds(0.07f);

        line.enabled = false;
    }
}
