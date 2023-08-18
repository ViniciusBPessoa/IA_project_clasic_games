using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Verificador_chao : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<Moviment_dino>().tocar_chao();
        }
    }

}
