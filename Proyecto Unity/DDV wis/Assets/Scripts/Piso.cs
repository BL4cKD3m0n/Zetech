using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piso : MonoBehaviour
{
    public Material[] material;
    public int x;
    Renderer rend;
    public GameObject c;


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
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {

            StartCoroutine(ContadorPisoRojo());
            x = 1;
            
        }
        else if(other.tag == "Player2")
        {
            StartCoroutine(ContadorPisoVerde());
            
            x = 2;
        }
    }
    IEnumerator ContadorPisoRojo()
    {
        cont cc = c.GetComponent<cont>();
        
        if (material[x].ToString() == "Piso_EstalaDown (UnityEngine.Material)")
        {
            cc.p1 += 1;
        }

        else if (material[x].ToString() == "piso verde (UnityEngine.Material)")
        {
            cc.p2 -= 1;
            cc.p1 += 1;
        }
        Debug.Log("rojo"+cc.p1);
        yield return new WaitForSeconds(.1f);
    }
    IEnumerator ContadorPisoVerde()
    {
        cont cc = c.GetComponent<cont>();

        if (material[x].ToString() == "Piso_EstalaDown (UnityEngine.Material)")
        {
            cc.p2 += 1;
        }

        else if (material[x].ToString() == "piso rojo (UnityEngine.Material)")
        {
            cc.p2 += 1;
            cc.p1 -= 1;
        }
        Debug.Log("verde"+cc.p2);
        yield return new WaitForSeconds(.1f);
    }





}
