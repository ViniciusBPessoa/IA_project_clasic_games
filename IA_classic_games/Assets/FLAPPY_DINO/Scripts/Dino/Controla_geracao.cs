using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controla_geracao : MonoBehaviour
{
    public Boolean melhorPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        if(melhorPlayer == true)
        {
            GameObject[] jogadores  = FindObjectsOfType<GameObject>();

            if (jogadores.Length > 20){
                for (int i = 0; i < jogadores.Length - 20; i++){
                    Destroy(jogadores[0]);
                }
            }

            foreach (GameObject jog in jogadores)
            {
                if(jog.CompareTag("Player") && jog != gameObject)
                {
                    //Aqui eu passaria as infos pra próxima geração
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.transform.position.y < -8)
        {
            Destroy(gameObject);
        }
    }
}
