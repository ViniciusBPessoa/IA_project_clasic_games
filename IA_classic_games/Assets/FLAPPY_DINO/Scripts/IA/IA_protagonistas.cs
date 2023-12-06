using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IA_protagonistas : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void Update() 
    {
        List<float> test = new List<float>();
        
        GameObject nextScore     = closestScore();
        float nextScoreDistance  = closestDistance(nextScore);
    
        // Debug.Log(gameObject.transform.position.y);
        // Debug.Log(nextScore.transform.position.y);
        // Debug.Log(nextScoreDistance);
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