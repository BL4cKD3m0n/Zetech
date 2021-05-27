using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInPause : MonoBehaviour
{
    // Start is called before the first frame update
    public void OnEnable()
    {
        Time.timeScale = 0f;
    }

    public void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
