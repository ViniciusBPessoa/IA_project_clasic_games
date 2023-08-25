using UnityEngine;

public class Seleciona_Sprite : MonoBehaviour
{
    public  Sprite           novaSprite1;
    public  Sprite           novaSprite2;
    private SpriteRenderer   sprite;

    // Start is called before the first frame update
    void Awake()
    {   
        sprite = GetComponent<SpriteRenderer>();
        trocaSprite();
    }
    public void trocaSprite()
    {
        int seleciona_sprite = Random.Range(1,9);

        if(seleciona_sprite >= 1 && seleciona_sprite <= 3)
        {
            sprite.sprite = novaSprite1;
        }
        else if(seleciona_sprite >= 4 && seleciona_sprite <= 6)
        {
            sprite.sprite = novaSprite2;
        }
    }
}
