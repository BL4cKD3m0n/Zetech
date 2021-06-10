using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HUD_Puntos : MonoBehaviour
{
    public Slider sliderVerde;
    public Gradient GradVerde;
    public Image FillVerde;
    

    public Slider sliderNaranja;
    public Gradient GradNaranja;
    public Image FillNaranja;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PuntuacionVerde(float PointsG)
    {
        sliderNaranja.value = PointsG;
    }

    public void PuntuacionNaranja(float PointsO)
    {
        sliderVerde.value = PointsO;
    }
}
//143 pisos totales