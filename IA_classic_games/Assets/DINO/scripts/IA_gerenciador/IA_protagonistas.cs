using System;
using System.Collections.Generic;
using UnityEngine;

public class IA_protagonistas : MonoBehaviour
{
    // Start is called before the first frame update

    public int numero_camadas;
    public int numero_neoronios_camada;
    public int numero_entradas;
    public int numero_saidas;
    public float amplitude_recalibragem;
    public Rede_neural Minha_mente;
    public List<float> lista_inputs = new List<float>();
    public bool is_alive = false;
    public Rigidbody2D rb;
    public float jumpForce = 30f;
    public bool isGrounded = false;
    public float peso = 2;
    public float ultima_pos_y = 1;
    public Animator animator;
    public bool inicio = false;
    void Start()
    {
        Minha_mente = new Rede_neural(numero_camadas, numero_neoronios_camada, numero_entradas, numero_saidas, amplitude_recalibragem);
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        amplitude_recalibragem = 0.1f;
    }

    private void Update() {

        if (is_alive == false)
        {

            GameObject obj = ScoreMaisPerto();
            float dist_cao = Math.Abs(gameObject.transform.position.y - -5.13544f);
            float velocidade = GameObject.FindGameObjectWithTag("GameController").GetComponent<MAP_Stats>().Map_velocidade;
            float dist_cao_inimi = Math.Abs(obj.transform.position.y - -5.13544f);
            float dist_vc_inimi = Math.Abs(gameObject.transform.position.y - obj.transform.position.y);
            float tamanho_inimigo =  GetObjectWidth(obj);
            lista_inputs = new List<float>
            {
                dist_cao,
                velocidade,
                dist_cao_inimi,
                dist_vc_inimi,
                tamanho_inimigo
            };

            List<bool> activate = Minha_mente.ativacao(lista_inputs);

            if(activate[0] == true && isGrounded == true){
                pulo();
            }
            if (activate[1] == true && isGrounded == false){
                rb.gravityScale = 30;
            }
            if(activate[1] == false){
                rb.gravityScale = 4;
            }
            if (inicio == true){
                ultima_pos_y = GameObject.FindGameObjectWithTag("GameController").GetComponent<MAP_Stats>().Map_pontuacao;
            }

            if (activate[1]){
                animator.SetBool("down", true);
            }else if (activate[1] == false){
                animator.SetBool("down", false);
            }

            if (isGrounded == false){
            animator.SetBool("pula", true);
            }else if(isGrounded == true) {
                animator.SetBool("pula", false);
            }
            if (is_alive == true){
                animator.SetBool("morto", true);
            }
        }

        
    }

    void pulo(){
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
        isGrounded = false;
    }

    public void tocar_chao()
    {
        isGrounded = true;
        rb.gravityScale = peso;
    }

public GameObject ScoreMaisPerto()
    {
        GameObject[] scoreEmTela;
        scoreEmTela = GameObject.FindGameObjectsWithTag("DINOinimigo");
        GameObject maisPerto = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;

        foreach (GameObject score in scoreEmTela)
        {
            if(score.transform.position.x > position.x){
                Vector3 diff = score.transform.position - position;
                float curDistance = diff.sqrMagnitude;
                if (curDistance < distance)
                {
                    maisPerto = score;
                    distance = curDistance;
                }
            }
        }
        return maisPerto;
    }

    float GetObjectWidth(GameObject obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();

        if (renderer != null)
        {
            return renderer.bounds.size.x;
        }

        Debug.LogWarning("O objeto não tem um Renderer.");
        return 0f;
    }

    // Update is called once per frame
}

[Serializable]
public class Neoronio
{
    public List<float> fios = new List<float>();
    public float pesos = 1f;
    public Neoronio(int num_neuro_atuais, int num_neuro_anteriores){
        int fdp = num_neuro_atuais * num_neuro_anteriores/num_neuro_atuais;
        for(int i = 0; i < fdp; i++){
            fios.Add(UnityEngine.Random.Range( -pesos, pesos));
        }
    }

    public float processar(List<float> entradas){
        List<float> aux_lista_int = new List<float>();
        float result = 0;

        for (int i = 0; i < fios.Count; i++)
        {
            aux_lista_int.Add(fios[i] * entradas[i]);
        }

        foreach (float item in aux_lista_int)
        {
            result += item;
        }
        if (result < 0){
            result = 0;
        }
        return result;
    }

    public void regulagem(float amplitude){
        for (int i = 0; i < fios.Count; i++)
        {
            fios[i] += UnityEngine.Random.Range(-amplitude, amplitude);
        }
    }
}
[Serializable]
public class Camada
{
    public List<Neoronio> neoronios = new List<Neoronio>();
    public Camada(int numero_neuronios, int entradas){

        for (int i = 0; i < numero_neuronios; i++){
            neoronios.Add(new Neoronio(numero_neuronios, entradas));
        }
    }

    public List<float> Ativacao(List<float> valores)
    {
        List<float> ativacao = new List<float>();

        foreach (Neoronio neuro in neoronios)
        {
            ativacao.Add(neuro.processar(valores));
        }
        return ativacao;
    }

    public void recalibrar(float amplitude)
    {
        for (int i = 0; i < neoronios.Count; i++)
        {
            neoronios[i].regulagem(amplitude);
        }
    }

}
[Serializable]
public class Rede_neural
{
    public float amplitude_recalibragem;
    public List<Camada> camadas = new List<Camada>();

    public Rede_neural(int numero_camadas, int numero_neuro_por_camada, int numero_entradas, int numero_saidas, float amplitude){

        amplitude_recalibragem = amplitude;

        camadas.Add(new Camada(numero_neuro_por_camada, numero_entradas));

        for (int i = 0; i < numero_camadas - 1; i++)
        {
            camadas.Add(new Camada(numero_neuro_por_camada, numero_neuro_por_camada));
        }

        camadas.Add(new Camada(numero_saidas, numero_neuro_por_camada));

    }

    public List<bool> ativacao(List<float> entrada)
    {
        List<bool> ret = new List<bool>();
        
        List<float> result = camadas[0].Ativacao(entrada);

        for (int i = 1; i < camadas.Count; i++)
        {
            result = camadas[i].Ativacao(result);
        }

        foreach (float item in result)
        {
            if(item == 0){
                ret.Add(false);
            }else{
                ret.Add(true);
            }
        }
        return ret;
    }

    public void recalibragem(){
        for (int i = 0; i < camadas.Count; i++)
        {
            camadas[i].recalibrar(amplitude_recalibragem);
        }
    }

}