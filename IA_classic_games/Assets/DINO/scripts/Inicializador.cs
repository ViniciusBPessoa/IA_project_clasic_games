using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inicializador : MonoBehaviour
{
    public float velocidade;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        velocidade = GameObject.FindGameObjectWithTag("GameController").GetComponent<MAP_Stats>().Map_velocidade;
        Vector3 movement = Vector3.left * velocidade * Time.deltaTime;
        transform.position += movement;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("IA_Play")){
            other.GetComponent<IA_protagonistas>().inicio = true;
        }
    }

}
