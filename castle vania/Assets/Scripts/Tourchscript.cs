using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tourchscript : MonoBehaviour
{
    public GameObject player;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other == player)
        {
            Destroy(gameObject);
        }
    }
}
