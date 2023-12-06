using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Generations : MonoBehaviour
{
    public GameObject passaritos_do_caralho;
    public int quantidade_geracao;
    public int quantidade_selecao;
    private EvolutionaryStrategy ES;
    
    private void Awake() 
    {

    }
    
    void Start()
    {   
        ES = new EvolutionaryStrategy(quantidade_selecao);
        // Verifica se é o primeiro carregamento da cena
        // Obtém a instância do GameManager
        GameManager gameManager = GameManager.Instance;

        // Obtém o valor atual da variável
        int valorAtual = gameManager.ObterMinhaVariavel();

        List<GameObject> listaPassaro = gameManager.ObterMinhalista();

        // Atualiza o valor da variável (por exemplo, adicionando 1)
        gameManager.AtualizarMinhaVariavel(valorAtual + 1);

        if (valorAtual == 0)
        {
            inicializate_one_time();
        }else{
            inicializate_second_time(listaPassaro);
        }

    }

    public void inicializate_one_time()
    {
        spowner_objects(quantidade_geracao);
    }
    public void inicializate_second_time(List<GameObject> listaPassaro)
    {
        spowner_object_list(listaPassaro);
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

        GameManager gameManager = GameManager.Instance;

        // Obtém o valor atual da variável
        gameManager.AtualizarMinhalista(ES.atualGeneration);
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
