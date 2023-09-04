using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controla_anima_IA : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private Movimenta_IA movimento;
    public float velocidade;
    public bool Morto_prot;
    public float volocidade_cenario;
    public float ultima_pos_y;
    public float ultima_pontuacao;

    public bool is_S;
    public bool is_space;
    void Start()
    {
        movimento = GetComponent<Movimenta_IA>();
        Morto_prot = false;
        ultima_pontuacao = 0;
        volocidade_cenario = GameObject.FindGameObjectWithTag("GameController").GetComponent<MAP_Stats>().Map_velocidade;
    }

    
    
}
