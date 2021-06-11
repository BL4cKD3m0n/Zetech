using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield_Campo : MonoBehaviour
{
    public Transform ShieldTf;

    public float RotationSpeed = 20f;
    public float VelocityOb = 1.8f;
    public float LifeDurationH;
    float lifeTimer;

    public float EffectDuration = 5f;
    public bool ActivateMove;
    public bool ActivateMove2;


    public GameObject Player1;
    public GameObject Escudo1;
    

    public GameObject Player2;
    public GameObject Escudo2;


    // Start is called before the first frame update
    void Start()
    {
        lifeTimer = LifeDurationH;
    }

    // Update is called once per frame
    void Update()
    {
        ShieldTf.Rotate(Vector3.up * RotationSpeed * Time.deltaTime);

        lifeTimer -= Time.deltaTime;
        if (lifeTimer <= 0)
        {
            gameObject.SetActive(false);
        }

        if (ActivateMove == true)
        {
            StartCoroutine(EfeccShield());
        }

        if (ActivateMove2 == true)
        {
            StartCoroutine(EfeccShield2());
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

    IEnumerator EfeccShield()
    {
        /*TopDownCharacterMover ScriptPj1 = Player1.GetComponent<TopDownCharacterMover>();

        ScriptPj1.WalkSpeed *= VelocityOb;

        gameObject.transform.localScale = Vector3.zero; //Instantiate(DS_Hermes, transform.position, transform.rotation);

        yield return new WaitForSeconds(EffectDuration);

        ScriptPj1.WalkSpeed *= VelocityOb;

        Destroy(gameObject);

        ActivateMove = false;*/

        ShieldTf.transform.localScale = Vector3.zero;

        Escudo1.SetActive(true);

        yield return new WaitForSeconds(EffectDuration);

        Escudo1.SetActive(false);

        Destroy(gameObject);

        ActivateMove = false;
    }

    IEnumerator EfeccShield2()
    {
        gameObject.transform.localScale = Vector3.zero;

        Escudo2.SetActive(true);

        yield return new WaitForSeconds(EffectDuration);

        Escudo2.SetActive(false);

        Destroy(gameObject);

        ActivateMove2 = false;
    }

}
