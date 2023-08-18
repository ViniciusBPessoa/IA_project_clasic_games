using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment_dino : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody2D rb;
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpForce = 30f;
        isGrounded = true;
    }

    void Update()
    {

        if(Input.GetButtonDown("Jump") && isGrounded){
            pulo();
        }

    }

    void pulo(){
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }

    public void tocar_chao()
    {
        isGrounded = true;
    }

}
