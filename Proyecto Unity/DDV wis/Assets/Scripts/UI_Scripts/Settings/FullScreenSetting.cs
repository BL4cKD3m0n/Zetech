using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FullScreenSetting : MonoBehaviour
{
    public Toggle Toggle;

    public TMP_Dropdown ResolutionDropD;
    Resolution[] resolutions;

    // Start is called before the first frame update
    void Start()
    {
        if(Screen.fullScreen)
        {
            Toggle.isOn = true;
        }
        else
        {
            Toggle.isOn = false;
        }

        CheckResolution();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateFullScreen(bool FullScreenBool)
    {
        Screen.fullScreen = FullScreenBool;
    }

    public void CheckResolution()
    {
        resolutions = Screen.resolutions;
        ResolutionDropD.ClearOptions();
        List<string> opciones = new List<string>();
        int ResolutionActual = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string opcion = resolutions[i].width + " x " + resolutions[i].height;
            opciones.Add(opcion);

            if (Screen.fullScreen && resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                ResolutionActual = i;
            }
        }
        ResolutionDropD.AddOptions(opciones);
        ResolutionDropD.value = ResolutionActual;
        ResolutionDropD.RefreshShownValue();

        ResolutionDropD.value = PlayerPrefs.GetInt("NumeroResolution", 0);
    }

    public void ChangeResolution(int IndiceResolution)
    {
        PlayerPrefs.SetInt("NumeroResolution", ResolutionDropD.value);

        Resolution resolucion = resolutions[IndiceResolution];
        Screen.SetResolution(resolucion.width, resolucion.height, Screen.fullScreen);
    }
}
