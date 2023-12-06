using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_pulo : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // Boolean realizaAcao = gameObject.GetComponent<IA_protagonistas>().acao;
        // Debug.Log(realizaAcao);
        // if (realizaAcao == true && gameObject.GetComponent<Pular>().playerMorto == false)
        // {
        //     Jump();
        // }
    }

    private void Jump()
    {
        gameObject.GetComponent<Pular>().Jump();
    }
}
