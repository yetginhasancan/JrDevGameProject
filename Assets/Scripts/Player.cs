using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Player Values")]
    [SerializeField] private float playerSpeed = 5f;
    [SerializeField] private float lerpSpeed = 5f;
    [SerializeField] private float playerXValue = 0.5f;

    [Header("Other Values")] 
    [SerializeField] private Animator animator;
    
    private Rigidbody rb;
    private float newXPos;
    private float startXPos;
    
    //Referencing rigidbody
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator.SetBool("isRunning",true);
    }

    //Checks horizontal inputs on update
    void Update()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            newXPos = transform.position.x + Input.GetAxisRaw("Horizontal") * playerXValue;
        }
    }
    
    //Moves our character
    private void FixedUpdate()
    {
        rb.MovePosition(new Vector3(Mathf.Lerp(transform.position.x,newXPos,lerpSpeed*Time.fixedDeltaTime),rb.velocity.y,transform.position.z+playerSpeed *Time.fixedDeltaTime));
    }
    
    //Checks if player touched with any obstacle
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Obstacle"))
            Respawn();
    }
    
    //Moves player to starting point
    private void Respawn()
    {
        gameObject.transform.position = new Vector3(0f,0.05f,0f);
    }
    
    //Stop player animation
    public void StopPlayer()
    {
        animator.SetBool("isRunning",false);
    }
}
