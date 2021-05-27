using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BrilloSetting : MonoBehaviour
{
    public Slider sliderBr;
    public float SliderValueBr;
    public Image PanelBrillo;

    // Start is called before the first frame update
    void Start()
    {
        sliderBr.value = PlayerPrefs.GetFloat("brillo", 0.5f);
        PanelBrillo.color = new Color(PanelBrillo.color.r, PanelBrillo.color.g, PanelBrillo.color.b, sliderBr.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PreferenciaUserBrillo(float valor)
    {
        SliderValueBr = valor;
        PlayerPrefs.SetFloat("brillo", SliderValueBr);
        PanelBrillo.color = new Color(PanelBrillo.color.r, PanelBrillo.color.g, PanelBrillo.color.b, 
            sliderBr.value);
    }
}
