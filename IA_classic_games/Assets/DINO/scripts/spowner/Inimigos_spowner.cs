using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus_spowner : MonoBehaviour
{
    public int percentual;
    public float taxa_passaro;
    public int taxa_pitero_voador = 50;

    private int porcentagem_total = 101;

    private float intervalo = 1.5f; // Intervalo em segundos
    private float tempoPassado = 0f; // Variável para contar os segundos

    private int pontuacao = 200;
    private int pontuaacao_nescessaria = 200;

    public GameObject[] inimigos_cactos;
    public GameObject[] inimigos_pitero;

    private int tamanho_pitero = 5;
    private int tamanho_cacto_min = 2;
    private int tamanho_cacto_max = 5;

    public float modificação_altura_cacto = 1.0f;

    public float modificação_altura_pitero_cabeca = 0.4f;
    public float modificação_altura_pitero_cabeca_mais = 0.4f;

    void Start()
    {
        taxa_passaro = 30;
        modificação_altura_pitero_cabeca = 0.3f;
        modificação_altura_pitero_cabeca_mais = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        tempoPassado += Time.deltaTime; // Incrementar o contador de segundos

        if (tempoPassado >= intervalo)
        {
            if (pontuacao >= pontuaacao_nescessaria)
            {   
                percentual = Random.Range(1, porcentagem_total);
                if (percentual <= taxa_passaro)
                {
                    Cria_Pitero();
                }else
                {
                    Cria_cactu();
                }
                tempoPassado = 0f;
            }else
            {
                Cria_cactu();
                tempoPassado = 0f;
            }
            
        }
    
    }

    public void Cria_cactu(){

        percentual = Random.Range(0, inimigos_cactos.Length);
        GameObject obj = inimigos_cactos[percentual];

        percentual = Random.Range(tamanho_cacto_min, tamanho_cacto_max);
        Vector2 newposi = new Vector2(transform.position.x, transform.position.y - modificação_altura_cacto);

        obj.transform.localScale = new Vector3(percentual, percentual + 1, percentual);
        Instantiate(obj, newposi, transform.rotation);

    }
    public void Cria_Pitero(){

        percentual = Random.Range(0, inimigos_pitero.Length);

        GameObject obj = inimigos_pitero[percentual];

        percentual = Random.Range(0, porcentagem_total);

        Vector2 newposi;

        if(percentual <= taxa_pitero_voador){
            newposi = new Vector2(transform.position.x, transform.position.y - modificação_altura_pitero_cabeca);
        }else{
            newposi = new Vector2(transform.position.x, transform.position.y + modificação_altura_pitero_cabeca_mais);
        }

        obj.transform.localScale = new Vector3(tamanho_pitero, tamanho_pitero, tamanho_pitero);
        Instantiate(obj, newposi, transform.rotation);

    }

}
