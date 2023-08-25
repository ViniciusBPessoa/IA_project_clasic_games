using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Controal_pontucao : MonoBehaviour
{

    public Text text_pontuatio;

    // Update is called once per frame
    public void Atualiza_tela(String texto){
        text_pontuatio.text = texto;
    }
}
