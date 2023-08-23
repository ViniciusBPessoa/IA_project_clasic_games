using System;
using UnityEngine;

public class Controla_protago : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private Moviment_dino movimento;

    public float velocidade;
    public bool Morto_prot;
    
    void Start()
    {
        movimento = GetComponent<Moviment_dino>();
        Morto_prot = false;
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.S)){
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
            animator.SetBool("morto", true);
        }

    }
}
