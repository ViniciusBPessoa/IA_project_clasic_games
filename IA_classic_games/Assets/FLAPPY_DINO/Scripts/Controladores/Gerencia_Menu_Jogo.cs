using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gerencia_Menu_Jogo : MonoBehaviour
{

    [SerializeField] private Button reiniciar;
    [SerializeField] private Button voltarMenu;

    // Start is called before the first frame update
    void Awake()
    {
        reiniciar.onClick.AddListener(onReiniciar);
        voltarMenu.onClick.AddListener(onVoltarMenu);
    }

    public void abrirMenu()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }
    public void fecharMenu()
    {
        gameObject.SetActive(false);
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
