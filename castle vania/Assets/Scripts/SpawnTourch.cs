using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTourch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Tourch;
    void Start()
    {
        for (int i =0;i< 5; i++)
        {
            GameObject cloneTourch = Instantiate(Tourch);
            cloneTourch.transform.position = new Vector2(-2.767f + (1.322f*i),-0.383f);
        }
    }

}
