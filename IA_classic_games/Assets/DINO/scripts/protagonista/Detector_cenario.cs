using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detector_cenario : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Dino_destroy")){
            Debug.Log("Bateu");
        }
    }

}
