using System;
using Unity.VisualScripting;
using UnityEngine;

public class Controla_protago : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private Moviment_dino movimento;
    public float velocidade;
    public bool Morto_prot;
    public float volocidade_cenario;
    public float ultima_pos_y;
    public float ultima_pontuacao;
    void Start()
    {
        movimento = GetComponent<Moviment_dino>();
        Morto_prot = false;
        ultima_pontuacao = 0;
        volocidade_cenario = GameObject.FindGameObjectWithTag("GameController").GetComponent<MAP_Stats>().Map_velocidade;
    }

    void Update()
    {

        if (Morto_prot != true){
            ultima_pos_y = transform.position.y;
        }

        if (Input.GetKey(KeyCode.S)){
            Debug.Log(Input.GetKey(KeyCode.S));
            animator.SetBool("down", true);
        }else{
            animator.SetBool("down", false);
        }

        if (movimento.isGrounded == false){
            animator.SetBool("pula", true);
        }else {
            animator.SetBool("pula", false);
        }

        if (Morto_prot == true){
            velocidade = volocidade_cenario;
            animator.SetBool("morto", true);
        }

        if (Morto_prot == false){
            ultima_pontuacao = GameObject.FindGameObjectWithTag("GameController").GetComponent<MAP_Stats>().Map_pontuacao;
        }

        Vector3 movement = Vector3.left * velocidade * Time.deltaTime;
        transform.position += movement;

    }

}
