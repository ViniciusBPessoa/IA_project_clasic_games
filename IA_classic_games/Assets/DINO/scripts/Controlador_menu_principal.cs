using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador_menu_principal : MonoBehaviour
{

    public String cena_jogo_solo;
    public String cena_jogo_treino;

    public void Jogar_solo(){
        SceneManager.LoadScene(cena_jogo_solo);
    }

    public void Treinar_IAL(){
        SceneManager.LoadScene(cena_jogo_treino);
    }
}
