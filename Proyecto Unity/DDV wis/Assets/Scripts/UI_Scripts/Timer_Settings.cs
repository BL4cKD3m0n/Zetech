using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer_Settings : MonoBehaviour
{

    float timer;
    public Text txtTimer;

    public Ctl_Menus PanelWinner;

    // Start is called before the first frame update
    void Start()
    {
        timer = 120f;
        txtTimer.text = timer.ToString("n0");

        PanelWinner = GameObject.FindGameObjectWithTag("PanelWinner").GetComponent<Ctl_Menus>();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        txtTimer.text = timer.ToString("n0");

        if (timer <= 0.0f)
        {
            PanelWinner.PantallaWinner.SetActive(true);
        }
    }
}
