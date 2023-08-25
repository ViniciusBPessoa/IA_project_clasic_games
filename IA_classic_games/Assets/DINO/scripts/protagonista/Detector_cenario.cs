using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector_cenario : MonoBehaviour
{
    private Controla_protago controlador;

    void Start()
    {
        controlador = GetComponent<Controla_protago>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DINOinimigo"))
        {
            controlador.Morto_prot = true;
        }
    }
}
