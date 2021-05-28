using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_Settings : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Respawn_Ps;
    public GameObject Player1;
    public GameObject Player2;
    public float Duration = 4f;

    public bool ActivateMove;
    public bool ActivateMove2;


    // Update is called once per frame
    void Update()
    {
        if(ActivateMove == true)
        {
            StartCoroutine(RespawnStop());
        }

        if (ActivateMove2 == true)
        {
            StartCoroutine(RespawnStop2());
        }
    }

    void OnTriggerEnter(Collider other)
    {
      if (other.CompareTag("Player1"))
        {
            ActivateMove = true;
            Player1.transform.position = Respawn_Ps.transform.position;
        }

        if (other.CompareTag("Player2"))
        {
            ActivateMove2 = true;
            Player2.transform.position = Respawn_Ps.transform.position;
        }
    }

    IEnumerator RespawnStop()
    {       
        TopDownCharacterMover ScriptPj1 = Player1.GetComponent<TopDownCharacterMover>();
        
        ScriptPj1.CanMove = false;

        yield return new WaitForSeconds(Duration);

        ScriptPj1.CanMove = true;

        ActivateMove = false;
    }

    IEnumerator RespawnStop2()
    {

        TopDownCharacterMover2 ScriptPj2 = Player2.GetComponent<TopDownCharacterMover2>();

        ScriptPj2.CanMove = false;

        yield return new WaitForSeconds(Duration);

        ScriptPj2.CanMove = true;

        ActivateMove2 = false;
    }
}
