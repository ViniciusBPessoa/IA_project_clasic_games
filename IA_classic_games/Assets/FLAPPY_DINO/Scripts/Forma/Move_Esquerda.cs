using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Esquerda : MonoBehaviour
{
    public int move = -2;
    // Start is called before the first frame update
    void Start()
    {
            
    }
    
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * move * Time.deltaTime);
    }
}
