using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wip : MonoBehaviour
{
    public Transform Simonpos;
    private int state = 1;

    private float attacktime;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);    
    }

    // Update is called once per frame
    private void Update()
    {
        transform.position = Simonpos.position;
    }
    void FixedUpdate()
    {
        
    }
}
