using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hermes_Velocity : MonoBehaviour
{
    public Transform Hermes;

    public float RotationSpeed = 20f;
    public float VelocityOb = 1.8f;
    public float LifeDurationH;
    float lifeTimer;

    //public GameObject DS_Hermes;
    public float EffectDuration = 4f;
    public bool ActivateMove;
    public bool ActivateMove2;
    public GameObject Player1;
    public GameObject Player2;

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
            gameObject.SetActive(false);
        }

        if (ActivateMove == true)
        {
            StartCoroutine(EfecctHermes());           
        }

        if (ActivateMove2 == true)
        {
            StartCoroutine(EfecctHermes2());
        }

    }

   private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            ActivateMove = true;
        }

        if (other.CompareTag("Player2"))
        {
            ActivateMove2 = true;
        }
    }
   IEnumerator EfecctHermes()
    {
        TopDownCharacterMover ScriptPj1 = Player1.GetComponent<TopDownCharacterMover>();

        ScriptPj1.WalkSpeed *= VelocityOb;

        gameObject.transform.localScale = Vector3.zero; //Instantiate(DS_Hermes, transform.position, transform.rotation);

        yield return new WaitForSeconds(EffectDuration);
       
        ScriptPj1.WalkSpeed *= VelocityOb;
       
        Destroy(gameObject);

        ActivateMove = false;     
    }

    IEnumerator EfecctHermes2()
    {
        TopDownCharacterMover2 ScriptPj2 = Player2.GetComponent<TopDownCharacterMover2>();

        ScriptPj2.WalkSpeed *= VelocityOb;

        gameObject.transform.localScale = Vector3.zero; //Instantiate(DS_Hermes, transform.position, transform.rotation);

        yield return new WaitForSeconds(EffectDuration);

        ScriptPj2.WalkSpeed *= VelocityOb;

        Destroy(gameObject);

        ActivateMove2 = false;
    }

}