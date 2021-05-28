using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rayo : MonoBehaviour
{
    public Transform rayo;

    [SerializeField]
    public float RotationSpeed = 20f;

    [SerializeField]
    public float VelocityOb = 1.8f;

    [SerializeField]
    public float LifeDurationH;
    public TopDownCharacterMover tp1;
    public TopDownCharacterMover tp2;
    public int x = 0;

    float lifeTimer;
    //public GameObject DS_Hermes;



    //Start
    private void Start()
    {
        lifeTimer = LifeDurationH;
        tp1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<TopDownCharacterMover>();
        tp2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<TopDownCharacterMover>();


    }

    // Update is called once per frame
    void Update()
    {

        rayo.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);

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
            StartCoroutine(EfecctRayo());
            x = 1;
        }
    }
    IEnumerator EfecctRayo()
    {
        if (x == 1)
        {
            Debug.Log("Recogi power Up: Hermes");
            tp2.WalkSpeed = 0f;
            Destroy(gameObject);
            yield return new WaitForSeconds(4);
            tp2.WalkSpeed = 8f;
        }
        

        //Instantiate(DS_Hermes, transform.position, transform.rotation);


    }
}
