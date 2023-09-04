using UnityEngine;

public class Destroy_cenario : MonoBehaviour
{
    Spown_fluor spowner;

    public GameObject obj;

    private void Start() {
        spowner = obj.GetComponent<Spown_fluor>();
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Dino_destroy")){
            spowner.cria_chao();
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("DINOinimigo")) {
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Nuvem")){
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Initial")){
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("Player")){
            other.GetComponent<Controla_protago>().velocidade = 0f;
            other.GetComponent<Controla_protago>().volocidade_cenario = 0f;
            other.GetComponent<Rigidbody2D>().simulated = false;
        }
    }
    

}
