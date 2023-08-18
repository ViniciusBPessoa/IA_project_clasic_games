using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerencia_Jogo : MonoBehaviour
{
    public float    eixoX;
    public float    eixoYbaixo;
    public float    eixoYcima;

    public  GameObject   forma;
    private GameObject   novaForma1;
    private GameObject   novaForma2;

    public float    temporizador;
    public float    aumentaDificuldade; 
    public double   dificuldade;

    public int  morreu;

    // Start is called before the first frame update
    void Awake()
    {   
        morreu = 0;
        geraForma();
    }

    // Update is called once per frame
    void Update()
    {

        if(morreu != 1){
            temporizador += Time.deltaTime;
            if(dificuldade > 0.9){
                aumentaDificuldade += Time.deltaTime;
            }
        }

        if(dificuldade > 0.9 && aumentaDificuldade > 10 && morreu != 1){
            dificuldade        -= 0.2;
            aumentaDificuldade  = 0;
        }

        if(temporizador > dificuldade && morreu != 1){
            geraForma();
            temporizador = 0;
        } 

    }

    public void geraForma(){
        eixoYcima = UnityEngine.Random.Range(2f,8f);
        eixoYbaixo = eixoYcima - 10;

        novaForma1 = Instantiate(forma);
        novaForma1.transform.position = new Vector2(eixoX, eixoYcima);

        novaForma2 = Instantiate(forma);
        novaForma2.transform.position = new Vector2(eixoX, eixoYbaixo);
    }

}
