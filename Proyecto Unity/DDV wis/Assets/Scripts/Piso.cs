using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Piso : MonoBehaviour
{
    public Material[] material;
    public int x;
    Renderer rend;
    public GameObject c;
    public HUD_Puntos HUD_Bar;
    void Start()
    {
        x = 0;
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[x];

        HUD_Bar.sliderVerde.value = 0.0f;
        HUD_Bar.GradVerde.Evaluate(0f);

        
        HUD_Bar.sliderNaranja.value = 0.0f;
        HUD_Bar.GradVerde.Evaluate(0f);
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

        HUD_Bar.PuntuacionNaranja(cc.p1);
        HUD_Bar.FillNaranja.color = HUD_Bar.GradNaranja.Evaluate(HUD_Bar.sliderNaranja.normalizedValue);

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

        HUD_Bar.PuntuacionVerde(cc.p2);
        HUD_Bar.FillVerde.color = HUD_Bar.GradVerde.Evaluate(HUD_Bar.sliderVerde.normalizedValue);

        Debug.Log("verde"+cc.p2);
        yield return new WaitForSeconds(.1f);
    }





}
