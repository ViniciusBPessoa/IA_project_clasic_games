using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Morte : MonoBehaviour 
{
    // Update is called once per frame
    private void Update()
    {
        if(gameObject.transform.position.y < -12)
        {
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.simulated = false;
        }
    }

    // Checa colisão do player com cacto ou terreno, se sim, mata o jogador
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Cacto") || other.gameObject.CompareTag("Terreno")){
            mataPlayer();
        }
    }

    // Função responsável por terminar o jogo com jogador todos jogadores mortos
    private void endGame()
    {
        GameObject[] gameObjectsInScreen = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in gameObjectsInScreen)
        {
            if(obj.GetComponent<Gerencia_Forma>() != null)
            {
                obj.GetComponent<Gerencia_Forma>().move = 0;
            }
        }
    }

    private void mataPlayer()
    {
        gameObject.GetComponent<Pular>().playerMorto = true;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity    = new Vector2(rb.velocity.x, 8);

        // Desabilita colisão dos jogadores mortos
        BoxCollider2D[] colisores = GetComponents<BoxCollider2D>();
        foreach (BoxCollider2D col in colisores)
        {
            col.enabled = false;
        }

        GameObject[] gameObjectsInScreen = FindObjectsOfType<GameObject>();
        
        // Checa se ainda há jogador vivo
        Boolean somePlayerAlive = false;
        foreach (GameObject obj in gameObjectsInScreen)
        {
            if(obj.CompareTag("Player"))
            {
                if(obj.GetComponent<Pular>().playerMorto == false)
                {
                    somePlayerAlive = true;
                    break;
                }
            }
        }

        // Termina jogo se todos jogadores mortos
        if(somePlayerAlive == false){
            endGame();
        }
    }
    
}
