using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hermes_Velocity : MonoBehaviour// PW_Ups //Ibox
{
    public Transform Hermes;

    [SerializeField]
    public float RotationSpeed = 20f;

    [SerializeField]
    public float VelocityOb = 1.8f;

    [SerializeField]
    public float LifeDurationH;
    public TopDownCharacterMover tp1;

    float lifeTimer;
    //public GameObject DS_Hermes;
    
    

    //Start
    private void Start()
    {
        lifeTimer = LifeDurationH;
        tp1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<TopDownCharacterMover>();
        

    }

    // Update is called once per frame
    void Update()
    {

        Hermes.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);

        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0)
        {
            gameObject.SetActive(false);
        }

    }

   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            StartCoroutine(EfecctHermes());
        }
    }
   IEnumerator EfecctHermes()
    {
        
        Debug.Log("Recogi power Up: Hermes");
        tp1.WalkSpeed *=1.8f;
        Destroy(gameObject);
        yield return new WaitForSeconds(4);
        tp1.WalkSpeed /= 1.8f;
        Debug.Log("power up end");
        
        

        //Instantiate(DS_Hermes, transform.position, transform.rotation);


    }

    

}