using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spown_fluor : MonoBehaviour
{
    public GameObject terra;
    private Vector2 pos_atual;
    private Quaternion pos_rotations;
    public float gap;
    // Start is called before the first frame update
    void Start()
    {
        pos_atual = transform.position;
        pos_rotations = transform.rotation;
        pos_atual.x -= gap;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Dino_destroy")){
            Instantiate(terra, pos_atual, pos_rotations);
        }
    }
}
