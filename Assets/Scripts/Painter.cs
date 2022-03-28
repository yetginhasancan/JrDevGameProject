using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painter : MonoBehaviour
{
    private Vector3 position = new Vector3(0, 0, 0);
    private Vector3 direction = Vector3.right;
    private float timer = 1f;
    private float timerLimit = 1f;
    
    
    void Update()
    {
        //Different approach for painting sequence
        
        //Checks for borders
        if(transform.localPosition.x>5)
            transform.Translate(position.x-5,position.y,position.z);
        if(transform.localPosition.y<-5)
            transform.Translate(position.x,position.y+5,position.z);
        if(transform.localPosition.x<0)
            transform.Translate(5,position.y,position.z);
        if(transform.localPosition.y>0)
            transform.Translate(position.x,-5,position.z);

        
        //Takes input in deltatime and moves the brush depending on input
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction.x = 0;
            direction.y = 1;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            direction.x = -1;
            direction.y = 0;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            direction.x = 0;
            direction.y = -1;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            direction.x = 1;
            direction.y = 0;
        }

        timer += Time.deltaTime;
        if (timer >= timerLimit)
        {
            transform.Translate(direction,transform.parent);
            timer -= timerLimit;
        }
        
        transform.Translate(position.x,position.y,0,transform.parent);

    }
    
}
