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

            /*ActiveObj = true;
            MostrarPausa(ActiveObj);

            if (ActiveObj == true && Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Q))
            {
                ActiveObj = false;
                PanelPausa.PantallaPausa.SetActive(ActiveObj);
            }*/
        }
    }
    /*public void MostrarPausa(bool ActiveObj)
    {
        PanelPausa.PantallaPausa.SetActive(ActiveObj);
    }*/

    public void MostrarPausa()
    {
        PanelPausa.PantallaPausa.SetActive(true);
    }
}
