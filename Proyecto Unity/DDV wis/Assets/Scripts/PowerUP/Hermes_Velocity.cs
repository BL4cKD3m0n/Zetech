using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hermes_Velocity : MonoBehaviour
{

    public Transform Hermes;

    [SerializeField]
    private float RotationSpeed =20f;

    [SerializeField]
    private float VelocityOb = 1.5f;

    [SerializeField]
    public float LifeDurationH;

    float lifeTimer;
    
    //Start
    private void Start()
    {
        lifeTimer = LifeDurationH;
    }

    // Update is called once per frame
    void Update()
    {

        Hermes.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);

        lifeTimer -= Time.deltaTime;
        if(lifeTimer <= 0)
        {
            gameObject.SetActive(false);
        }

         

    }
}
