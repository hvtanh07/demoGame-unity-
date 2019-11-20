using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonMovement : MonoBehaviour
{
    public float speed;

    public LayerMask whatIsGround;
    public Transform groundCheck;
    public bool isGrounded;
    public float jumpForce;
    public GameObject wip;


    private float attacktime;
    private bool attacking;
    float x;

    private bool right = true;
    private bool walking = false;
    private bool sitting = false;
    private bool jumping = false;
    Rigidbody2D rb;
    Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        //jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }

        //attack
        if (Input.GetButtonDown("Slow"))
        {
            if (Time.timeScale == 0.15f)
                Time.timeScale = 1f;
            else
                Time.timeScale = 0.15f;
        }
        if (Input.GetButtonDown("Attack"))
        {
            if (!walking && !attacking)
            {
                attacking = true;
                anim.SetTrigger("Attack");
                wip.SetActive(true);
                attacktime = Time.time;
            }
        }
        if (Time.time - attacktime >= 0.17f)
        {
            wip.SetActive(false);
            attacking = false;
        }
    }
    void FixedUpdate()
    {
        //sit && jump
        isGrounded = Physics2D.OverlapPoint(groundCheck.position, whatIsGround);


        jumping = !isGrounded;

        if (Input.GetKey("down"))
        {
            if (sitting == false)
            {
                sitting = true;
                transform.position = new Vector2(transform.position.x, transform.position.y - 0.03f);
            }
        }
        else
        {
            if (sitting == true)
            {
                transform.position = new Vector2(transform.position.x, transform.position.y + 0.03f);
                sitting = false;
            }
        }

        anim.SetBool("Sit", sitting || jumping);




        //movement
        if (!jumping) { 
            x = Input.GetAxis("Horizontal");
        }
        if (x != 0) anim.SetBool("Walking", true);
        else anim.SetBool("Walking", false);

        if (x < 0)
        {
            walking = true;
            x = -1;
            right = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (x > 0)
        {
            walking = true;
            x = 1;
            right = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else walking = false;

        if (sitting) x = 0;

        transform.position = new Vector2(transform.position.x + x * speed, transform.position.y);       
    }
}
