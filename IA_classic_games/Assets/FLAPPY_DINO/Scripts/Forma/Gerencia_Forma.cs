using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerencia_Forma : MonoBehaviour
{
    public int move;
    public int eixoDestruir;
    public GameObject Gerencia_Jogo;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Gerencia_Jogo.GetComponent<Gerencia_Jogo>().morreu);

        while(Gerencia_Jogo.GetComponent<Gerencia_Jogo>().morreu != 1){
            move = 0;
        }

        if(Gerencia_Jogo.GetComponent<Gerencia_Jogo>().dificuldade > 10 
                && Gerencia_Jogo.GetComponent<Gerencia_Jogo>().morreu != 1){
            move += 1;
        }

        gameObject.transform.Translate(Vector2.left * move * Time.deltaTime);

        if(gameObject.transform.position.x < eixoDestruir){
            Destroy(gameObject);        
        }
    }
}
