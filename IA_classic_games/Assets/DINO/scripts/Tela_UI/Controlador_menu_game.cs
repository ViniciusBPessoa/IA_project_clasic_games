using UnityEngine;
using UnityEngine.SceneManagement;

public class Controlador_menu_game : MonoBehaviour
{
    public string cena_jogo_solo;
    public string vai_menu;
    public void Jogar_solo(){
        SceneManager.LoadScene(cena_jogo_solo);
    }

    public void veltar_menu(){
        SceneManager.LoadScene(vai_menu);
    }
}
