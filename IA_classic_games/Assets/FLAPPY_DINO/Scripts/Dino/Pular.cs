using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pular : MonoBehaviour
{
    public  float       jumpForce;
    private Rigidbody2D rb;
    public  Boolean     playerMorto = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMorto == false)
        {
            if (Input.GetButtonDown("Jump") == true)
            {
                Jump();
            }
        }
        
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
