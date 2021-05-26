using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame_Options : MonoBehaviour
{
    public ControllerOptions PanelOption;
    // Start is called before the first frame update
    void Start()
    {
        PanelOption = GameObject.FindGameObjectWithTag("Opciones").GetComponent<ControllerOptions>(); 
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MostrarPanelOpciones()
    {
        PanelOption.PantallaOpciones.SetActive(true);
    }
}
