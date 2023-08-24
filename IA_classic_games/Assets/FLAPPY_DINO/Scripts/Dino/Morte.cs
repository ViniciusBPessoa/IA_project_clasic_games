using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Morte : MonoBehaviour
{
    public Boolean fimJogo;

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -15)
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.CompareTag("Cacto")){
            mataPlayer();
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Terreno")){
            mataPlayer();
        }
    }

    public void terminaJogo()
    {
        GameObject[] objetosEmJogo = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in objetosEmJogo)
        {
            if(obj.GetComponent<Gerencia_Forma>() != null)
            {
                obj.GetComponent<Gerencia_Forma>().move = 0;
            }
        }
        fimJogo = true;
    }

    public void mataPlayer()
    {
        gameObject.GetComponent<Pular>().playerMorto = true;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, 8);

        BoxCollider2D[] colisores = GetComponents<BoxCollider2D>();
        foreach (BoxCollider2D col in colisores){
            col.enabled = false;
        }

        GameObject[] jogadores = FindObjectsOfType<GameObject>();
        foreach (GameObject jog in jogadores)
        {
            if(jog.CompareTag("Player")){
                if(jog.GetComponent<Pular>().playerMorto == false)
                {
                    break;
                }
            }else{
                terminaJogo();
            }
        }

    }
}
