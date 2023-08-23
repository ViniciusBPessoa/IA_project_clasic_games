using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verificador_chao : MonoBehaviour
{
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Moviment_dino>().tocar_chao();
        }
    }

}
