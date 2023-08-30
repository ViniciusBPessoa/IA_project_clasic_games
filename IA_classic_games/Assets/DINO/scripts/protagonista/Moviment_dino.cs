using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment_dino : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody2D rb;

    public bool isGrounded;
    public bool isagachado;

    private float peso;
    private float multiplicacao_peso;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpForce = 30f;
        isGrounded = true;
        isagachado = false;
        peso = rb.gravityScale;
        multiplicacao_peso = 3;

    }

    void Update()
    {

        if(Input.GetButtonDown("Jump") && isGrounded){
            pulo();
        }

        if(Input.GetKeyDown(KeyCode.S) && isGrounded == false){
            rb.gravityScale = peso * multiplicacao_peso;
        }

        if (Input.GetKeyUp(KeyCode.S)){
            rb.gravityScale = 4;
        }


    }

    void pulo(){
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }

    public void tocar_chao()
    {
        isGrounded = true;
        rb.gravityScale = peso;
    }

}
