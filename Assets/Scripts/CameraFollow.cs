using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;
    void Start()
    {
        //Setting offset to current value
        offset = transform.position - player.position;
    }
    
    //Simple camera follower that does not moves on x and follows from back
    void Update()
    {
        Vector3 targetPos = player.position + offset;
        targetPos.x = 0;
        transform.position = targetPos;
    }
}
