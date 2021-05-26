using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScenes : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake()
    {
        var noDestruirEntreEscenas = FindObjectsOfType<ChangeScenes>();
        if (noDestruirEntreEscenas.Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);

    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
