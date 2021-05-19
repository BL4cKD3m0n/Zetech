using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piso : MonoBehaviour
{
    public Material[] material;
    public int x;
    Renderer rend;

    void Start()
    {
        x = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];
    }
    void Update()
    {
        rend.sharedMaterial = material[x];
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player1")
        {
            x = 1;
        }
        else if(other.tag == "Player2")
        {
            x = 2;
        }
    }
}
