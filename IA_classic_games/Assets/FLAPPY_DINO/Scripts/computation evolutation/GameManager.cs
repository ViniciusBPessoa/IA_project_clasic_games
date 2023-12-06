using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Variável que será mantida entre cenas
    [SerializeField] private int minhaVariavel = 0;
    [SerializeField] private List<GameObject> passaros;

    private static GameManager instance;

    // Propriedade para acessar a instância do GameManager
    public static GameManager Instance
    {
        get
        {
            // Se a instância ainda não foi definida, procura por ela na cena
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>();

                // Se não encontrou GameManager na cena, cria um novo objeto GameManager
                if (instance == null)
                {
                    GameObject gameManagerObj = new GameObject("GameManager");
                    instance = gameManagerObj.AddComponent<GameManager>();
                }

                DontDestroyOnLoad(instance.gameObject);
            }

            return instance;
        }
    }
    // Método para obter o valor atual da variável
    public int ObterMinhaVariavel()
    {
        return minhaVariavel;
    }

    // Método para atualizar o valor da variável
    public void AtualizarMinhaVariavel(int novoValor)
    {
        minhaVariavel = novoValor;
    }
    public List<GameObject> ObterMinhalista()
    {
        return passaros;
    }

    // Método para atualizar o valor da variável
    public void AtualizarMinhalista(List<GameObject> novoValor)
    {
        passaros = novoValor;
    }
}