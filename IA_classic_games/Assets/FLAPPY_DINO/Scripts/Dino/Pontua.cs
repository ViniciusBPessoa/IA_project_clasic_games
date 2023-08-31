using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Pontua : MonoBehaviour
{
    public int score;
    public Text scoreText;

    private Boolean checaToque;
    
    private void OnTriggerEnter2D(Collider2D other) {

        if(other.gameObject.CompareTag("EnableScore"))
        {
            checaToque = false;
        }

        if(other.gameObject.CompareTag("Score") && checaToque == false)
        {
            score ++;

            GameObject[] dino = FindObjectsOfType<GameObject>();
            int maxPonto = 0;

            foreach (GameObject obj in dino)
            {
                if(obj.GetComponent<Pontua>() != null && obj.GetComponent<Pontua>().score > maxPonto)
                {
                    maxPonto = obj.GetComponent<Pontua>().score;
                }
            }
            
            checaToque = true;

            scoreText.text = maxPonto.ToString();
        }
    }
}
