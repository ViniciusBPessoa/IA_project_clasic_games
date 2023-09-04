using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SponerDinos_IA : MonoBehaviour
{
    public GameObject prefabToSpawn; // O objeto que você deseja instanciar.
    public Vector2 spawnPoint; // O ponto de origem (spawner).
    public int numberOfObjectsToSpawn = 10; // Número de objetos a serem instanciados.
    public float gapBetweenObjects = 1.0f; // Espaço entre os objetos.

    void Start()
    {
        spawnPoint = gameObject.transform.position;
        // Loop para instanciar os objetos com o espaço especificado entre eles.
        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            // Calcula a posição do próximo objeto com base no espaço e no índice.
            Vector2 vetor = new (spawnPoint.x - gapBetweenObjects, spawnPoint.y);
            gapBetweenObjects -= gapBetweenObjects;

            // Instancia o objeto na posição calculada.
            GameObject spawnedObject = Instantiate(prefabToSpawn, vetor, transform.rotation);
        }
    }
}
