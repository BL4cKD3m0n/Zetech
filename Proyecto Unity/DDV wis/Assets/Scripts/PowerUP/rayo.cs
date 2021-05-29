using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rayo : MonoBehaviour
{
    public Transform RayoObj;

    public float RotationSpeed = 20f;
    public float LifeDurationH;
    float lifeTimer;

    //public GameObject DS_Hermes;
    public float EffectDuration = 4f;
    public bool ActivateMove;
    public bool ActivateMove2;
    public GameObject Player1;
    public GameObject Player2;
    public int x = 0;


    //Start
    private void Start()
    {
        lifeTimer = LifeDurationH;
    }

    // Update is called once per frame
    void Update()
    {
        RayoObj.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);

        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0)
        {
            gameObject.SetActive(false);
        }

        if (ActivateMove == true)
        {
            StartCoroutine(EfecctRayo());
        }

        if (ActivateMove2 == true)
        {
            StartCoroutine(EfecctRayo2());
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player1"))
        {
            ActivateMove = true;
            x = 1;
        }

        if (other.CompareTag("Player2"))
        {
            ActivateMove2 = true;
            x = 2;
        }
    }
    IEnumerator EfecctRayo()
    {
        TopDownCharacterMover2 ScriptPj2 = Player2.GetComponent<TopDownCharacterMover2>();

        if (x == 1)
        {
            ScriptPj2.CanMove = false;

            gameObject.transform.localScale = Vector3.zero;

            ScriptPj2.AnimMov.SetTrigger("InjuredT");

            yield return new WaitForSeconds(EffectDuration);

            ScriptPj2.CanMove = true;

            Destroy(gameObject);

            ActivateMove = false;
        }
    }

    IEnumerator EfecctRayo2()
    {
        TopDownCharacterMover ScriptPj1 = Player1.GetComponent<TopDownCharacterMover>();

        if (x == 2)
        {
            ScriptPj1.CanMove = false;

            gameObject.transform.localScale = Vector3.zero;

            ScriptPj1.AnimMov.SetTrigger("InjuredT");

            yield return new WaitForSeconds(EffectDuration);

            ScriptPj1.CanMove = true;

            Destroy(gameObject);

            ActivateMove2 = false;
        }
    }
}
