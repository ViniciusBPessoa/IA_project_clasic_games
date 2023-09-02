using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerencia_Jogo: MonoBehaviour
{
    public float        eixoX;
    public float        eixoY;

    public  GameObject  forma;
    private GameObject  novaForma;
    public  GameObject  dino;
    public  GameObject  menuJogo;
    public  GameObject melhorPlayer;
    public float        temporizador;
    public float        aumentaDificuldade; 
    public double       dificuldade;


    // Start is called before the first frame update
    void Awake()
    {   
        //DontDestroyOnLoad(this.gameObject);
        Time.timeScale = 1;
        geraForma();
    }

    void Start()
    {
        melhorPlayer = new GameObject("");
    }

    // Update is called once per frame
    void Update()
    {
        if(checaFim() == false)
        {
            if(dificuldade > 0.9)
            {
                aumentaDificuldade += Time.deltaTime;

                if(aumentaDificuldade > 10)
                {
                    dificuldade        -= 0.2;
                    aumentaDificuldade  = 0;
                }
            }

            temporizador += Time.deltaTime;

            if(temporizador > dificuldade)
            {
                geraForma();
                temporizador = 0;
            }
        }
        else
        {

            GameObject[] jogadores  = FindObjectsOfType<GameObject>();
            int aux = 0;

            foreach (GameObject jog in jogadores)
            {
                if(jog.CompareTag("Player") && jog.GetComponent<Pontua>().score >= aux)
                {
                    aux = jog.GetComponent<Pontua>().score;
                    melhorPlayer = jog;
                }
            }
            
            Debug.Log("Melhor jogador: " + melhorPlayer.name);
            melhorPlayer.GetComponent<Controla_geracao>().melhorPlayer = true;
            menuJogo.GetComponent<Gerencia_Menu_Jogo>().abrirMenu();
        }
    }

    public void geraForma()
    {
        eixoY = UnityEngine.Random.Range(1f,-2.92f);

        novaForma = Instantiate(forma);
        novaForma.transform.position = new Vector2(eixoX, eixoY);
    }
    
    public Boolean checaFim()
    {
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

        if(alguemVivo == false)
        {
            return true;
        }

        return false;
    }

}
