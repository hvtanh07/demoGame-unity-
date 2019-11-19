using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonAttack : MonoBehaviour
{
    private Animator anim;
    private float attacktime;
    private bool attacking;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Attack")){
            attacking = true;
            anim.SetTrigger("Attack");
            attacktime = Time.deltaTime;
            Debug.Log("attacking");
        }
        if (Time.deltaTime - attacktime >= 3)
        {
            attacking = false;
            Debug.Log("stopped");
        }
    }
}
