using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_protagonistas : MonoBehaviour
{
    [SerializeField] public NeuralNetwork nw;
    // Start is called before the first frame update
    void Start()
    {
        // Inicia rede neural e starta os pesos e o bias
        nw = this.gameObject.GetComponent<NeuralNetwork>();
        nw.InitializeWeightsAndBiases();
    }
    private void Update() 
    {
        bool morto = GetComponent<Morte>().is_alive;
        List<float> test = new List<float>();
        
        GameObject nextScore     = closestScore();
        float nextScoreDistance  = closestDistance(nextScore);
        float objecty            = gameObject.transform.position.y;
        float nextScorey         = nextScore.transform.position.y;

        double[] inputs  = new double[]{objecty, nextScorey, nextScoreDistance};
        double[] actions = nw.Predict(inputs);

        // realize actions();
        if (actions[0] == 1 && morto == true){
            gameObject.GetComponent<Pular>().Jump();
        }
    }

    public GameObject closestScore()
    {
        GameObject[] scoresInScreen;
        scoresInScreen     = GameObject.FindGameObjectsWithTag("Score");
        GameObject closest = null;
        float distance     = Mathf.Infinity;
        Vector3 position   = transform.position;

        foreach (GameObject score in scoresInScreen)
        {
            // BUSCA POR GAMEOBJECTS A DIREITA
            if(score.transform.position.x > position.x){
                Vector3 diff      = score.transform.position - position;
                float newDistance = diff.sqrMagnitude;
                if (newDistance < distance)
                {
                    closest  = score;
                    distance = newDistance;
                }
            }
        }

        return closest;
    }

    public float closestDistance(GameObject nextScore)
    {
        float distancia = nextScore.transform.position.x - gameObject.transform.position.x;
        return distancia;
    }
}

