using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wip : MonoBehaviour
{
    public Transform Simonpos;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
        transform.position = Simonpos.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
