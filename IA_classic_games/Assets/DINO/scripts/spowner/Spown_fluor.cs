using UnityEngine;

public class Spown_fluor : MonoBehaviour
{
    public GameObject terra;
    private Vector2 pos_atual;
    private Quaternion pos_rotations;
    public float gap;
    
    GameObject posi_to_spown;

    void Start()
    {
        pos_rotations = transform.rotation;
        gap = 0.2f;
        posi_to_spown = GameObject.FindGameObjectWithTag("Spowner_cao");
    }


    public void cria_chao()
    {
        Vector2 posi = new Vector2(posi_to_spown.transform.position.x - gap, posi_to_spown.transform.position.y);
        Instantiate(terra, posi, pos_rotations);
        
    }
}
