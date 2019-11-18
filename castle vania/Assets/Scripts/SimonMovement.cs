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

    public Animator anim;

    private bool right = true;
    private bool sitting = false;
    private bool jumping = false;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        sitting = false;
        if (Input.GetKey("down"))
        {
            if (sitting == false)
            {
                sitting = true;
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
