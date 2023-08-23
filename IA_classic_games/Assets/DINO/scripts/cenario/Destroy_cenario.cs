using UnityEngine;

public class Destroy_cenario : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Dino_destroy") || other.gameObject.CompareTag("DINOinimigo")){
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Nuvem")){
            Destroy(other.gameObject);
        }
    }
    

}
