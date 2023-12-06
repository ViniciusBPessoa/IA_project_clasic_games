using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gerencia_Menu_Jogo : MonoBehaviour
{

    [SerializeField] private Button reiniciar;
    [SerializeField] private Button voltarMenu;
    public  GameObject  gerencia_Jogo;

    // Start is called before the first frame update
    void Awake()
    {
        reiniciar.onClick.AddListener(onReiniciar);
        voltarMenu.onClick.AddListener(onVoltarMenu);
    }

    void Update()
    {
        
    }

    public void abrirMenu()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);

    }
    public void fecharMenu()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
        gerencia_Jogo.GetComponent<Gerencia_Jogo>().isPaused = false;
    }

    // Update is called once per frame
    private void onReiniciar()
    {
        SceneManager.LoadScene(0);
        fecharMenu();
    }
    private void onVoltarMenu()
    {
        SceneManager.LoadScene(1);
    }
}
