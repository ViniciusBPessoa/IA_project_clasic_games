using UnityEngine;

public class Move : MonoBehaviour
{
    public float moveSpeed = 5f; // Velocidade de movimento do jogador

    void Update()
    {
        // Obter entrada do teclado
        float horizontalInput = Input.GetAxis("Vertical");
        float hs = Input.GetAxis("Horizontal");

        // Calcular a direção do movimento
        Vector3 moveDirection = new Vector3(hs, horizontalInput, 0f);

        // Calcular a nova posição do jogador
        transform.position += moveDirection * moveSpeed * Time.deltaTime;
    }
}
