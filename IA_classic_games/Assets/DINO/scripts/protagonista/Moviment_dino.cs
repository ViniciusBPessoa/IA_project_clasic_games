using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment_dino : MonoBehaviour
{
    public float jumpForce;
    private Rigidbody2D rb;
    private BoxCollider2D meu_colizor;

    public bool isGrounded;
    public bool isagachado;

    private float peso;
    private float multiplicacao_peso;

    public Vector2 diferenca_agacado_altura;
    public Vector2 diferenca_agacado_posicao;

    public Vector2 diferenca_agacado_altura_original;
    public Vector2 diferenca_agacado_posicao_original;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        meu_colizor = GetComponent<BoxCollider2D>();
        jumpForce = 30f;
        isGrounded = true;
        isagachado = false;
        peso = rb.gravityScale;
        multiplicacao_peso = 3;

        diferenca_agacado_altura_original = new Vector2(meu_colizor.size.x, meu_colizor.size.y);
        diferenca_agacado_posicao_original = new Vector2(meu_colizor.offset.x, meu_colizor.offset.y);

        diferenca_agacado_altura = new Vector2(0.24f, 0.116618f);
        diferenca_agacado_posicao = new Vector2(0, -0.1039732f);
    }

    void Update()
    {

        if(Input.GetButtonDown("Jump") && isGrounded){
            pulo();
        }

        if(Input.GetKey(KeyCode.S) && isGrounded == false){
            rb.gravityScale = peso * multiplicacao_peso;
        }

        if(Input.GetKeyDown(KeyCode.S)){
            isagachado = true;
        }

        if(Input.GetKeyUp(KeyCode.S)) {
            isagachado = false;
        }

        agacha();

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

    public void agacha(){

        if(isagachado == true){
            meu_colizor.size = diferenca_agacado_altura;
            meu_colizor.offset  =  diferenca_agacado_posicao;
        }
        else{
             meu_colizor.size = diferenca_agacado_altura_original;
             meu_colizor.offset = diferenca_agacado_posicao_original;
        }
            
    }

}
