using UnityEngine;

public class nuvem_andar : MonoBehaviour
{
    [HideInInspector]
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = GameObject.FindGameObjectWithTag("GameController").GetComponent<MAP_Stats>().Map_velocidade;

        
        int jesus = Random.Range(1, 11);

        if(gameObject.tag == "Nuvem" && jesus <= 5){
            moveSpeed /= 2;
        }
        if(gameObject.tag == "Nuvem" && jesus <= 8){
            moveSpeed /= 3;
        }
        if(gameObject.tag == "Nuvem" && jesus <= 10){
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.left * moveSpeed * Time.deltaTime;
        transform.position += movement;
    }
}
