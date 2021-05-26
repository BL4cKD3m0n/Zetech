using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumenSetting : MonoBehaviour
{
    public Slider slider;
    public float SliderValue;
    public Image ImagenMute;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("VolumenAudio", 1.0f);
        AudioListener.volume = slider.value;
        CheckMuted();
    }

    public void PreferenciaUserAudio(float valor)
    {
        SliderValue = valor;
        PlayerPrefs.SetFloat("VolumenAudio", SliderValue);
        AudioListener.volume = slider.value;
        CheckMuted();
    }

    public void CheckMuted()
    {
        if(SliderValue == 0)
        {
            ImagenMute.enabled = true;
        }
        else
        {
            ImagenMute.enabled = false;
        }
    }
}
