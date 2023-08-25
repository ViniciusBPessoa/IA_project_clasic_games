using UnityEngine;
using TMPro;

public class MAP_Stats : MonoBehaviour
{
    public float Map_velocidade;
    public float Map_pontuacao;

    public float passagem_velocidade;
    public GameObject[] obj;

    public GameObject[] players;

    public TextMeshProUGUI pontos_UI;

    public GameObject menu_morte;

    void Awake()
    {
        Map_velocidade = 7;
        Map_pontuacao = 0;

        passagem_velocidade = 0.1f;
    }

    private void Start() {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    void Update()
    {

        Map_pontuacao += Map_velocidade / 2 * Time.deltaTime;
        pontos_UI.text = Mathf.Floor(Map_pontuacao).ToString();

        if (Map_pontuacao >= passagem_velocidade)
        {
            passagem_velocidade += 0.1f;
            Map_velocidade += 0.001f;

            GameObject[] nuvens = GameObject.FindGameObjectsWithTag("Nuvem");
            GameObject[] dinoDestroy = GameObject.FindGameObjectsWithTag("Dino_destroy");
            GameObject[] dinoInimigo = GameObject.FindGameObjectsWithTag("DINOinimigo");

            obj = new GameObject[nuvens.Length + dinoDestroy.Length + dinoInimigo.Length];
            nuvens.CopyTo(obj, 0);
            dinoDestroy.CopyTo(obj, nuvens.Length);
            dinoInimigo.CopyTo(obj, nuvens.Length + dinoDestroy.Length);

            foreach (GameObject item in obj)
            {
                Chao_andar chaoAndarComponent = item.GetComponent<Chao_andar>();
                if (chaoAndarComponent != null)
                {
                    chaoAndarComponent.moveSpeed = Map_velocidade;
                }
            }
        }

        para_cena();
    }

    public bool Verifica_fim_cena(){
        bool verificador = false;
        foreach (GameObject item in players)
        {
            if (item.GetComponent<Controla_protago>().Morto_prot == false){
                verificador = true;
            }
        }
        return verificador;
    }

    public void para_cena(){
        bool verifica = Verifica_fim_cena();

        if(verifica == false){
            menu_morte.SetActive(true);
            Time.timeScale = 0f;
        }

    }

}
