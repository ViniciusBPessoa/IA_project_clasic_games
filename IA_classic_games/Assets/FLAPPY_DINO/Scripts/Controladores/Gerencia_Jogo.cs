using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gerencia_Jogo: MonoBehaviour
{
    public float        eixoX;
    public float        eixoY;

    public  GameObject  forma;
    private GameObject  novaForma;
    public  GameObject  dino;

    public float        temporizador;
    public float        aumentaDificuldade; 
    public double       dificuldade;


    // Start is called before the first frame update
    void Awake()
    {   
        geraForma();
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

    }

    public void geraForma()
    {
        eixoY = UnityEngine.Random.Range(1f,-2.92f);

        novaForma = Instantiate(forma);
        novaForma.transform.position = new Vector2(eixoX, eixoY);
    }
    
    public Boolean checaFim()
    {
        if(dino.GetComponent<Morte>().fimJogo == true)
        {
            return true;
        }
        return false;
    }

}
