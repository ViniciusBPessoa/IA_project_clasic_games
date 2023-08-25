using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerencia_Nuvem : MonoBehaviour
{
    public GameObject nuvem01;
    public GameObject nuvem02;
    private float randomTime;
    private float randomTimeMax = 1;
    private float randomTimeMin = 2;
    private float contaTempo;
    public GameObject gerencia_Jogo;

    // Start is called before the first frame update
    void Start()
    {
        randomTime = UnityEngine.Random.Range(randomTimeMax,randomTimeMin);
    }

    // Update is called once per frame
    void Update()
    {
        if(gerencia_Jogo.GetComponent<Gerencia_Jogo>().checaFim() == false)
        {
            contaTempo += Time.deltaTime;

            if(contaTempo > randomTime)
            {
                GameObject novaForma;

                int escolheNuvem    = UnityEngine.Random.Range(1,3);
                int velocidadeNuvem = UnityEngine.Random.Range(3,6);

                if(escolheNuvem == 1)
                {
                    novaForma = Instantiate(nuvem01);
                }
                else
                {
                    novaForma = Instantiate(nuvem02);
                }

                float eixoY = UnityEngine.Random.Range(-3f,3f);

                novaForma.transform.position = new Vector3(gameObject.transform.position.x, eixoY, 0.5f);
                novaForma.GetComponent<Gerencia_Forma>().move = velocidadeNuvem;

                randomTime = UnityEngine.Random.Range(randomTimeMax,randomTimeMin);
                contaTempo = 0;
            }
        } 

    }
}
