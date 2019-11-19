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

   

    private bool right = true;
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
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapPoint(groundCheck.position, whatIsGround);

        float x = Input.GetAxis("Horizontal");

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

        anim.SetBool("Sit", sitting||jumping);

        

        if (x != 0) anim.SetBool("Walking", true);
        else anim.SetBool("Walking", false);

        if (x < 0)
        {  
            x = -1;
            right = false;
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (x > 0)
        {
            x = 1;
            right = true;
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        
        if (sitting) x = 0;

        transform.position = new Vector2(transform.position.x + x * speed, transform.position.y);

    }
}
