using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hermes_Velocity : MonoBehaviour //PW_Ups //Ibox
{
    public Transform Hermes;

    [SerializeField]
    private float RotationSpeed = 20f;

    [SerializeField]
    private float VelocityOb = 1.8f;

    [SerializeField]
    public float LifeDurationH;

    float lifeTimer;
    public GameObject DS_Hermes;

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
        if (lifeTimer <= 0)
        {
            //gameObject.SetActive(false);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            EfecctHermes();
        }
    }
    void EfecctHermes()
    {
        Debug.Log("Recogi power Up: Hermes");
        Instantiate(DS_Hermes, transform.position, transform.rotation);
        //Destroy(gameObject);
    }

    /*int PW_Ups.getID()
    {
        return (int)PW_UpsID.VELOX2;
    }

    float PW_Ups.GetEffects()
    {
        return VelocityOb;
    }*/

}