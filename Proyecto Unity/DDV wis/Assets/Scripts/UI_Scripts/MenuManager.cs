using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void BotonStart()
    {
        SceneManager.LoadScene("In_Game");
    }

    public void BotonQuit()
    {
        Debug.Log("Aplicación Cerrada");
        Application.Quit();
    }

    public void VueltalMainMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }

    public void FinGame(bool FinalGame)
    {
        if(FinalGame == true)
        {
            Debug.Log("LA PARTIDA HA TERMINADO");
        }

            
    }
}
