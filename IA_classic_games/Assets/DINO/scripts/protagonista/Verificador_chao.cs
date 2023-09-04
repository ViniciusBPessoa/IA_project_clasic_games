using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verificador_chao : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Moviment_dino>().tocar_chao();
        }
        if(other.gameObject.tag == "IA_Play")
        {
            other.gameObject.GetComponent<IA_protagonistas>().tocar_chao();
        }
    }
}
