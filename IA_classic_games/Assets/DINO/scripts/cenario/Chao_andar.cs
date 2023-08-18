using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chao_andar : MonoBehaviour
{
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 3;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = Vector3.left * moveSpeed * Time.deltaTime;
        transform.position += movement;
    }
}
