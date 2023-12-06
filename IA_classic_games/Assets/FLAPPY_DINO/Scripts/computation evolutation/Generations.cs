using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Generations : MonoBehaviour
{
    public GameObject passaritos_do_caralho;
    public int quantidade_geracao;
    public int quantidade_selecao;
    private EvolutionaryStrategy ES;
    
    // Variável estática para verificar se a cena foi carregada pela primeira vez
    private static bool firstLoad = true;

    private void Awake() 
    {
        DontDestroyOnLoad(this.gameObject);
    }
    
    void Start()
    {   
        // Verifica se é o primeiro carregamento da cena
        if (firstLoad)
        {
            inicializate_one_time();
            firstLoad = false;
        }
        else
        {
            inicializate_second_time();
        }
    }

    public void inicializate_one_time()
    {
        
        spowner_objects(quantidade_geracao);
        ES = new EvolutionaryStrategy(quantidade_selecao);
        Debug.Log("uma");

    }

    public void inicializate_second_time()
    {
        
        Debug.Log("duas");
        spowner_object_list(ES.atualGeneration);

    }

    public void spowner_objects(int quantidade)
    {
        Vector3 positionToInstantiate = transform.position;
        for (int i = 0; i < quantidade; i++)
        {                
            Instantiate(passaritos_do_caralho, positionToInstantiate, Quaternion.identity);
        }
    }
    public void spowner_object_list(List<GameObject> entidade)
    {
        
        Vector3 positionToInstantiate = transform.position;
        foreach (GameObject passaro in entidade)
        {
             Instantiate(passaro, positionToInstantiate, Quaternion.identity);
        }

    }

    public void fim_episode()
    {
        List<GameObject> lista_passaros = GameObject.FindGameObjectsWithTag("Player").ToList();
        ES.generationCreator(lista_passaros);
        SceneManager.LoadScene(0);
    }
    public class EvolutionaryStrategy
    {
        public List<GameObject> atualGeneration;
        int numberSelected;

        public EvolutionaryStrategy(int numberSelected)
        {
            
            this.numberSelected = numberSelected;

        }

        public void generationCreator(List<GameObject> entities)
        {
            atualGeneration = new List<GameObject>();

            // Ordena a lista de entidades com base no componente "Pontua" e sua variÃ¡vel "score"
            List<GameObject> sortedEntities = entities.OrderBy(entity => entity.GetComponent<Pontua>().score).ToList();

            // Seleciona os 'numberSelected' melhores itens da lista ordenada
            List<GameObject> selectedEntities = sortedEntities.Take(numberSelected).ToList();

            int aux = 0;
            bool reseted = false;
            for (int i = 0; i < entities.Count; i++)
            {
                atualGeneration.Add(selectedEntities[aux]);
                aux++;
                if (aux >= selectedEntities.Count)
                {
                    aux = 0;
                    reseted = true;
                }

                if (reseted)
                {
                    atualGeneration[aux].GetComponent<IA_protagonistas>().nw.Train();
                }

            }
        }


    }


}
