using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tourchscript : MonoBehaviour
{
    public LayerMask weapon;
    private Transform self;
    private void Awake()
    {
        self = GetComponent<Transform>();
    }
    void FixedUpdate()
    {
        if (Physics2D.OverlapPoint(self.position, weapon))
        {
            Debug.Log("Touched");
            Destroy(gameObject);
        }
    }
}
