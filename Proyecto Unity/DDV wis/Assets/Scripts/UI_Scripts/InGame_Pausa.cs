using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame_Pausa : MonoBehaviour
{
    public ControllerPausa PanelPausa;
    // Start is called before the first frame update
    void Start()
    {
        PanelPausa = GameObject.FindGameObjectWithTag("PanelPausa").GetComponent<ControllerPausa>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            MostrarPanelPausa();
        }
    }

    public void MostrarPanelPausa()
    {
        PanelPausa.PantallaPausa.SetActive(true);
    }
}
