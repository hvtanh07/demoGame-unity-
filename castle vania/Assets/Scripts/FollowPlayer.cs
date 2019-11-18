using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerpos;
    private void FixedUpdate()
    {
        if (playerpos.position.x <= -2.484) 
            transform.position = new Vector3(-2.48f, 0, -10);
        else if (playerpos.position.x >= 2.7659)
            transform.position = new Vector3(2.7659f, 0, -10);
        else
            transform.position = new Vector3(playerpos.position.x, 0, -10);
    }
}
