using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus_spowner : MonoBehaviour
{
    public int percentual;
    public float taxa_passaro;

    public GameObject prefab; // Prefab do objeto que você deseja instanciar
    private float intervalo = 1.5f; // Intervalo em segundos
    private float tempoPassado = 0f; // Variável para contar os segundos

    private int pontuacao = 200;
    private int pontuaacao_nescessaria = 200;

    public Object[] inimigos;
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
        Instantiate(inimigos[percentual],this.transform.position , this.transform.rotation);
    }
    public void Cria_Pitero(){
        Instantiate(inimigos[inimigos.Length - 1],this.transform.position , this.transform.rotation);
    }

}
