using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerencia_Forma : MonoBehaviour
{
    public int move = 6;
    public int eixoDestruir;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(Vector2.left * move * Time.deltaTime);

        if(gameObject.transform.position.x < eixoDestruir){
            Destroy(gameObject);        
        }
    }

}
