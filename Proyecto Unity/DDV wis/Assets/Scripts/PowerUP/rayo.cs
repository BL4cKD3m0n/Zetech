using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayo : MonoBehaviour
{
    public Transform Rayo;

    [SerializeField]
    public float RotationSpeed = 20f;


    [SerializeField]
    public float VelocityOb = 0f;

    [SerializeField]
    public float LifeDurationH;
    public TopDownCharacterMover tp1;
    public TopDownCharacterMover2 tp2;
    public int x = 0;

    float lifeTimer;
    //public GameObject DS_Hermes;



    //Start
    private void Start()
    {
        lifeTimer = LifeDurationH;
        tp1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<TopDownCharacterMover>();
        tp2 = GameObject.FindGameObjectWithTag("Player1").GetComponent<TopDownCharacterMover2>();

    }

    // Update is called once per frame
    void Update()
    {

        Rayo.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);

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
            tp2.WalkSpeed = 0;
            Destroy(gameObject);
            yield return new WaitForSeconds(4);
            tp2.WalkSpeed = 8f;
            Debug.Log("Recogi power Up: Rayo");
        }
        
        


    }
}
