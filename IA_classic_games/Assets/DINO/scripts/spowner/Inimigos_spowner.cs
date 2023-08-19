using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus_spowner : MonoBehaviour
{
    public int percentual;
    public float taxa_passaro;

    private float intervalo = 1.5f; // Intervalo em segundos
    private float tempoPassado = 0f; // Variável para contar os segundos

    private int pontuacao = 200;
    private int pontuaacao_nescessaria = 200;

    public GameObject[] inimigos;
    void Start()
    {
        taxa_passaro = 30;
    }

    // Update is called once per frame
    void Update()
    {
        tempoPassado += Time.deltaTime; // Incrementar o contador de segundos

        if (tempoPassado >= intervalo)
        {
            if (pontuacao >= pontuaacao_nescessaria)
            {   
                percentual = Random.Range(1, 101);
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

        percentual = Random.Range(0, 4);
        GameObject obj = inimigos[percentual];

        percentual = Random.Range(3, 5);

        Vector2 newposi = new Vector2(transform.position.x, transform.position.y - 1);

        obj.transform.localScale = new Vector3(percentual, percentual + 1, percentual);
        Instantiate(obj, newposi, transform.rotation);

    }
    public void Cria_Pitero(){

        Vector2 newposi = new Vector2(transform.position.x, transform.position.y - 0.4f);
        GameObject obj = inimigos[inimigos.Length - 1];
        obj.transform.localScale = new Vector3(5, 5, 5);
        Instantiate(obj, newposi, transform.rotation);

    }

}
