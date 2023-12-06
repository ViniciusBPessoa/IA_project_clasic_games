using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Algoritimo_evolucionario : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

            // Ordena a lista de entidades com base no componente "Pontua" e sua variável "score"
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
                    // atualGeneration[aux].GetComponent<IA_protragonistas>.neuralNetwork.Train();
                }

            }
        }


    }

}