using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGame_MenusOpen : MonoBehaviour
{
    public Ctl_Menus PanelPausa;

    //public bool ActiveObj = false;

    // Start is called before the first frame update
    void Start()
    {
        PanelPausa = GameObject.FindGameObjectWithTag("PanelPausa").GetComponent<Ctl_Menus>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P))
        {
            MostrarPausa();
        }
    }


    public void MostrarPausa()
    {
        PanelPausa.PantallaPausa.SetActive(true);
    }
}
