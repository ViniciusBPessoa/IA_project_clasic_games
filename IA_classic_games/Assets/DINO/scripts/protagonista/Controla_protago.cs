using System;
using UnityEngine;

public class Controla : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    private Moviment_dino movimento;

    public float velocidade;
    
    void Start()
    {
        movimento = GetComponent<Moviment_dino>();
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

    }
}
