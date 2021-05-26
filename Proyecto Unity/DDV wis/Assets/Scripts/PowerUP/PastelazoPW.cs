using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PastelazoPW : MonoBehaviour
{

    [SerializeField]
    private float SpeedLaunch;

    [SerializeField]
    public float LifeDurationH;

    float lifeTimer;

    public bool ShootByPlayer;

    // Start is called before the first frame update
    void OnEnable()
    {
      
        lifeTimer = LifeDurationH;

    }

    // Update is called once per frame
    void Update()
    {
        
        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0)
        {
            gameObject.SetActive(false);
        }

        

    }

    private void FixedUpdate()
    {
        transform.position += transform.forward * SpeedLaunch * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Pastel Choca = " + other.name);

        IDamage damage = other.GetComponent<IDamage>();
        if(damage != null)
        {
            damage.DoDamage(ShootByPlayer);
        }
    }

}
