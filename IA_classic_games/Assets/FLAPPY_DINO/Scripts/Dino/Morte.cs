using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Morte : MonoBehaviour
{
    public Boolean fimJogo;

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -12)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.simulated = false;
        }
        
        resetaCena();

    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Cacto") || other.gameObject.CompareTag("Terreno")){
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
        foreach (BoxCollider2D col in colisores)
        {
            col.enabled = false;
        }

        GameObject[] jogadores = FindObjectsOfType<GameObject>();
        
        Boolean alguemVivo = false;
            
        foreach (GameObject jog in jogadores)
        {
            if(jog.CompareTag("Player"))
            {
                if(jog.GetComponent<Pular>().playerMorto == false)
                {
                    alguemVivo = true;
                    break;
                }
            }
        }

        if(alguemVivo == false){
            terminaJogo();
        }
        
    }

    void resetaCena()
    {
        GameObject[] jogadores = FindObjectsOfType<GameObject>();
        
        Boolean todosMortos = true;
            
        foreach (GameObject jog in jogadores)
        {
            if(jog.CompareTag("Player"))
            {
                if(jog.transform.position.y > -12)
                {
                    todosMortos = false;
                    break;
                }
            }
        }

        if(todosMortos == true){
            //SceneManager.LoadScene(0);
        }
    }
}
