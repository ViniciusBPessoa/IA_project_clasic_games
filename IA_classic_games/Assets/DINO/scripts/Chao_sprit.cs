
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chao_sprit : MonoBehaviour
{
    public Sprite[] spriteOptions;
    private SpriteRenderer sprit;

    private void Start()
    {
        sprit = GetComponent<SpriteRenderer>();
        troca_sprit();
    }

    private void troca_sprit()
    {
        
        int indice_random = Random.Range(0, spriteOptions.Length);
        sprit.sprite = spriteOptions[indice_random];
        
        
    }

    // Update is called once per frame
    private void Update()
    {
        // Se você não precisa de nada no Update por enquanto, você pode removê-lo.
    }
}
