using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reinicializador_IA : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Lista_jogadores;
    private bool is_frist_time = true;

    public Rede_neural rede_Neural_melor;
    Rede_neural AUX_IA_MELHOR;

    public int geracao = 0;
private void Awake() {
    DontDestroyOnLoad(this.gameObject);
}

    void Start()
    {
        Lista_jogadores = GameObject.FindGameObjectsWithTag("IA_Play");
    }

    // Update is called once per frame
    public void finaliza(){
        Lista_jogadores = GameObject.FindGameObjectsWithTag("IA_Play");
        float aux_pontos = 0;

        foreach (GameObject IA in Lista_jogadores)
        {
            IA_protagonistas pont = IA.GetComponent<IA_protagonistas>();
            if(pont.ultima_pos_y > aux_pontos){
                aux_pontos = pont.ultima_pos_y;
                AUX_IA_MELHOR = pont.Minha_mente;
            }
        }
        Debug.Log(aux_pontos);
        rede_Neural_melor = AUX_IA_MELHOR;
    }
    public void inicializa(){
        geracao++;
        Lista_jogadores = GameObject.FindGameObjectsWithTag("IA_Play");
        if(is_frist_time == false){
            foreach (GameObject IA in Lista_jogadores)
            {
                IA.GetComponent<IA_protagonistas>().Minha_mente = rede_Neural_melor;
                IA.GetComponent<IA_protagonistas>().Minha_mente.recalibragem();
            }

            Lista_jogadores[0].GetComponent<IA_protagonistas>().Minha_mente = rede_Neural_melor;
        }
        is_frist_time = false;

    }
}
