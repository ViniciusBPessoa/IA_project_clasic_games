using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pontua : MonoBehaviour
{
    [SerializeField]
    private int score = 0;
    public Text textoScore;
    // Start is called before the first frame update
    void Start()
    {
        textoScore.text = "21";
    }

    // Update is called once per frame
    void Update()
    {
        textoScore.text = score.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Score"))
        {
            score ++;
        }
        other.enabled = false;
    }
}
