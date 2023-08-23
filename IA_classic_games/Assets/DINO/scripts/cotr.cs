using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSpriteColor : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        // Obtém o componente SpriteRenderer do GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Verifica se o jogador pressionou a tecla R para mudar a cor do sprite para vermelho
        if (Input.GetKeyDown(KeyCode.R))
        {
            ChangeColor(Color.red);
        }
    }

    // Função para mudar a cor do sprite
    void ChangeColor(Color newColor)
    {
        spriteRenderer.color = newColor;
    }
}
