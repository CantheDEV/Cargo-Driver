using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] private float steerSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float boostSpeed;
    [SerializeField] private float bumpSpeed;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float zTurn = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float yMove = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-zTurn);
        transform.Translate(0, yMove, 0f);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject)
        {
            moveSpeed = bumpSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Boost")
        {
            moveSpeed = boostSpeed;
        }
    }
}
