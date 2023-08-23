using UnityEngine;

public class Chao_sprit : MonoBehaviour
{
    public Sprite[] spriteOptions;
    public SpriteRenderer sprit;
    
    [SerializeField]
    private int liso_reder;

    private void Start()
    {
        sprit = GetComponent<SpriteRenderer>();
        troca_sprit();
    }

    private void troca_sprit()
    {
        
        int indice_random = Random.Range(1, 101);

        if (indice_random <= liso_reder) {
            indice_random = Random.Range(0, 2);
            sprit.sprite = spriteOptions[indice_random];
        }
        else{
            indice_random = Random.Range(2, 4);
            sprit.sprite = spriteOptions[indice_random];
        }

        

    }
}
