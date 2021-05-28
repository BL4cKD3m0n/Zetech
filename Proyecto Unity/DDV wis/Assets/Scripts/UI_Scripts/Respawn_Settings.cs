using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_Settings : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Respawn_Ps;
    public GameObject Player1;
    public GameObject Player2;
    public TopDownCharacterMover ScriptPj1;
    public TopDownCharacterMover2 ScriptPj2;
    public bool EfectoSg;
    void Start()
    {
        ScriptPj1 = GameObject.FindGameObjectWithTag("Player1").GetComponent<TopDownCharacterMover>();
        ScriptPj2 = GameObject.FindGameObjectWithTag("Player2").GetComponent<TopDownCharacterMover2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
      if (other.CompareTag("Player1"))
        {
            StartCoroutine(RespawnStop());
            Player1.transform.position = Respawn_Ps.transform.position;
        }

        if (other.CompareTag("Player2"))
        {
            StartCoroutine(RespawnStop());
            Player2.transform.position = Respawn_Ps.transform.position;
        }
    }

    IEnumerator RespawnStop()
    {
        EfectoSg = true;

        yield return new WaitForSeconds(4);
        EfectoSg = false;
    }
}
