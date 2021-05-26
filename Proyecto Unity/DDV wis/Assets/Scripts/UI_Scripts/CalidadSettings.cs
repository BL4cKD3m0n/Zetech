using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CalidadSettings : MonoBehaviour
{

    public TMP_Dropdown dropdown;
    public int Calidad;

    // Start is called before the first frame update
    void Start()
    {
        Calidad = PlayerPrefs.GetInt("numeroDeCalidad", 3);
        dropdown.value = Calidad;
        AjustarCalidad();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AjustarCalidad()
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        PlayerPrefs.SetInt("numeroDeCalidad", dropdown.value);
        Calidad = dropdown.value;
    }
}
