using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reinicializador_IA : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Lista_jogadores;
    private bool is_frist_time = true;


private void Awake() {
    DontDestroyOnLoad(this.gameObject);
}

    void Start()
    {
        Lista_jogadores = GameObject.FindGameObjectsWithTag("IA_Play");
    }

    // Update is called once per frame
    public void finaliza(){
        
    }
    public void inicializa(){

        if(!is_frist_time){
            
        }

    }
}
