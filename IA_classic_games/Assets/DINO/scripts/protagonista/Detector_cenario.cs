using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector_cenario : MonoBehaviour
{
    private Controla_protago controlador;
    private IA_protagonistas controlador_IA;
    void Start()
    {
        if (gameObject.tag == "Player"){
            controlador = GetComponent<Controla_protago>();
        }else{
            controlador_IA = GetComponent<IA_protagonistas>();
        }
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DINOinimigo"))
        {
            if (gameObject.tag == "Player"){
                controlador.Morto_prot = true;
            }else{
                controlador_IA.is_alive = true;
            }
            
            gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
}
