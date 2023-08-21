using UnityEngine;

public class Spawner : MonoBehaviour
{
    public int percentual;
    public GameObject prefab; // Prefab do objeto que você deseja instanciar
    public float minY = -2.29f;
    public float maxY = 3.32f;
    private float intervalo = 1.5f; // Intervalo em segundos

    private float tempoPassado = 0f; // Variável para contar os segundos

    void Start()
    {
        percentual = 8;
    }

    void Update()
    {
        tempoPassado += Time.deltaTime; // Incrementar o contador de segundos

        if (tempoPassado >= intervalo)
        {
            gear_nuvem();
            tempoPassado = 0f; // Reiniciar o contador
        }
    }

    void gear_nuvem()
    {
        int indiceRandom = Random.Range(1, 21);

        if (indiceRandom <= percentual)
        {
            Vector3 spawnPosition = new Vector3(transform.position.x, Random.Range(minY, maxY), transform.position.z);
            Instantiate(prefab, spawnPosition, Quaternion.identity);
        }
    }
}
