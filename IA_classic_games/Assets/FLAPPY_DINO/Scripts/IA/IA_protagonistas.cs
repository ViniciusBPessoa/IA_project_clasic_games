using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_protagonistas : MonoBehaviour
{
    // Start is called before the first frame update

    public int numero_camadas;
    public int numero_neoronios_camada;
    public int numero_entradas;
    public int numero_saidas;
    public int amplitude_recalibragem;
    public Boolean acao;
    public Rede_neural Minha_mente;

    void Start()
    {
        Minha_mente = new Rede_neural(numero_camadas, numero_neoronios_camada, numero_entradas, numero_saidas, amplitude_recalibragem);
    }

    private void Update() 
    {
        List<float> teste = new List<float>();
        
        GameObject proxScore     = ScoreMaisPerto();
        float distanciaProxScore = DistanciaMaisPerto(proxScore);

        teste.Add(gameObject.transform.position.y);     // Altura dino
        teste.Add(proxScore.transform.position.y);      // Altura do pivô do score
        teste.Add(distanciaProxScore);                  // Distância do próximo score

        acao = Minha_mente.ativacao(teste)[0];          // Única saída 1 = pula 0 = não faz nada
    }

    public GameObject ScoreMaisPerto()
    {
        GameObject[] scoreEmTela;
        scoreEmTela = GameObject.FindGameObjectsWithTag("Score");
        GameObject maisPerto = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject score in scoreEmTela)
        {
            if(score.transform.position.x > position.x){
                Vector3 diff = score.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    maisPerto = score;
                    distance = curDistance;
                }
            }
        }

        return maisPerto;
    }

    public float DistanciaMaisPerto(GameObject proxScore)
    {
        float distancia = proxScore.transform.position.x - gameObject.transform.position.x;
        return distancia;
    }


}

[Serializable]
public class Neoronio
{
    public List<float> fios = new List<float>();
    public float pesos = 1f;
    public Neoronio(int num_neuro_atuais, int num_neuro_anteriores)
    {
        int fdp = (num_neuro_atuais * num_neuro_anteriores)/num_neuro_atuais;
        for(int i = 0; i < fdp; i++)
        {
            fios.Add(UnityEngine.Random.Range( -pesos, pesos));
        }
    }

    public float processar(List<float> entradas)
    {
        List<float> aux_lista_int = new List<float>();
        float result = 0;

        for (int i = 0; i < fios.Count; i++)
        {
            aux_lista_int.Add(fios[i] * entradas[i]);
        }

        foreach (float item in aux_lista_int)
        {
            result += item;
        }
        if (result < 0){
            result = 0;
        }
        return result;
    }

    public void regulagem(int amplitude)
    {
        for (int i = 0; i < fios.Count; i++)
        {
            fios[i] += UnityEngine.Random.Range(-amplitude, amplitude);
        }
    }

}
[Serializable]
public class Camada
{
    public List<Neoronio> neoronios = new List<Neoronio>();
    public Camada(int numero_neuronios, int entradas)
    {
        for (int i = 0; i < numero_neuronios; i++){
            neoronios.Add(new Neoronio(numero_neuronios, entradas));
        }
    }

    public List<float> Ativacao(List<float> valores)
    {
        List<float> ativacao = new List<float>();

        foreach (Neoronio neuro in neoronios)
        {
            ativacao.Add(neuro.processar(valores));
        }
        return ativacao;
    }

    public void recalibrar(int amplitude)
    {
        for (int i = 0; i < neoronios.Count; i++)
        {
            neoronios[i].regulagem(amplitude);
        }
    }

}
[Serializable]
public class Rede_neural
{
    public int amplitude_recalibragem;
    public List<Camada> camadas = new List<Camada>();

    public Rede_neural(int numero_camadas, int numero_neuro_por_camada, int numero_entradas, int numero_saidas, int amplitude){

        amplitude_recalibragem = amplitude;

        camadas.Add(new Camada(numero_neuro_por_camada, numero_entradas));

        for (int i = 0; i < numero_camadas - 1; i++)
        {
            camadas.Add(new Camada(numero_neuro_por_camada, numero_neuro_por_camada));
        }

        camadas.Add(new Camada(numero_saidas, numero_neuro_por_camada));

    }

    public List<bool> ativacao(List<float> entrada)
    {
        List<bool> ret = new List<bool>();
        
        List<float> result = camadas[0].Ativacao(entrada);

        for (int i = 1; i < camadas.Count; i++)
        {
            result = camadas[i].Ativacao(result);
        }

        foreach (float item in result)
        {
            if(item == 0){
                ret.Add(false);
            }else{
                ret.Add(true);
            }
        }
        return ret; //Uma única saída, ou pula ou não faz nada
    }

    public void recalibragem(){
        for (int i = 0; i < camadas.Count; i++)
        {
            camadas[i].recalibrar(amplitude_recalibragem);
        }
    }

}