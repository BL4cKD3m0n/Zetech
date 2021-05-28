using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Settings : MonoBehaviour
{

    public float timer;
    public Text txtTimer;

    public Ctl_Menus PanelWinner;

    public HUD_Puntos PuntajeTotal;
    public Image WachoNaranja;
    public Image WachoVerde;

    private bool ActivatePanels;
   //ImagenMute.enabled = true;
    // Start is called before the first frame update
    void Start()
    {
        ActivatePanels = false;
        txtTimer.text = timer.ToString("n0");

        PanelWinner = GameObject.FindGameObjectWithTag("PanelWinner").GetComponent<Ctl_Menus>();
    }

    // Update is called once per frame
    void Update()
    {
        ActivatePanels = true;
        timer -= Time.deltaTime;
        txtTimer.text = timer.ToString("n0");

        if (timer <= 0.0f)
        {
            PanelWinner.PantallaWinner.SetActive(ActivatePanels);

            if (ActivatePanels == true && PuntajeTotal.sliderNaranja.value < PuntajeTotal.sliderVerde.value) 
            {
                WachoVerde.enabled = true;
                WachoNaranja.enabled = false;
            }

            if (ActivatePanels == true && PuntajeTotal.sliderNaranja.value > PuntajeTotal.sliderVerde.value)
            {
                WachoNaranja.enabled = true;
                WachoVerde.enabled = false;
            }
        }
    }
}
