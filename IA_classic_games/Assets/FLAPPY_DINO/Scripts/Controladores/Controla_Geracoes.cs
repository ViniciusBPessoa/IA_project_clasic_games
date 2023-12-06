using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controla_Geracoes : MonoBehaviour
{
    public  GameObject gerencia_Jogo;
    public  GameObject bird;
    private GameObject newBird;
    [SerializeField] private bool firstGeneration;
    [SerializeField] private float x;
    [SerializeField] private float y;
    [SerializeField] private int n;
    private List<GameObject> birdList;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        
        // Gera 100 pássaros aleatórios na primeira iteração
        if (firstGeneration != false)
        {
            for (int i = 1; i <= n; i++)
                {
                    newBird = Instantiate(bird);
                    newBird.transform.position = new Vector2(x, y);

                    birdList = new List<GameObject>();
                    birdList.Add(newBird);
                }
            firstGeneration = false;
        }
        else
        {
            // chamar o algoritmo evolutivo para fazer a avaliação e retornar os pássaros para a próxima geração
            // birdList = geneticAlgorythm(birdList)

            // Pegar esses pássaros e instanciá-los para o próximo episódio
            foreach (GameObject b in birdList)
            {
                newBird = Instantiate(b);
                newBird.transform.position = new Vector2(x, y+200);

                birdList = new List<GameObject>();
                birdList.Add(newBird);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
