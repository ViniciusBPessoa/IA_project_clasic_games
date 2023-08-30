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
    }
    

}
