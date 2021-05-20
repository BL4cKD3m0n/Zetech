using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolingManager : MonoBehaviour
{
    struct MunicionInfo
    {
        public GameObject prefab;
        public PastelazoPW scriptPastelazoPW;
    }

    public static ObjectPoolingManager instance;
    public GameObject PastelazoPrefab;
    public int municiPastel = 1;

    private List<MunicionInfo> Pasteles;

    // Start is called before the first frame update
    void Awake()
    {

        instance = this;
        Pasteles = new List<MunicionInfo>(municiPastel);
        for(int i = 0; i<municiPastel; i++)
        {
            MunicionInfo PPrefab;
            PPrefab.prefab = Instantiate(PastelazoPrefab);
            PPrefab.prefab.transform.SetParent(transform);
            PPrefab.prefab.SetActive(false);
            PPrefab.scriptPastelazoPW = PPrefab.prefab.GetComponent<PastelazoPW>();
            Pasteles.Add(PPrefab);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetMunicion(bool isPlayer)
    {

        int totalmunicionPas = Pasteles.Count;
        for(int i=0; i<totalmunicionPas; i++)
        {
            if(!Pasteles[i].prefab.activeInHierarchy)
            {
                Pasteles[i].prefab.SetActive(true);
                Pasteles[i].scriptPastelazoPW.ShootByPlayer = isPlayer;

                return Pasteles[i].prefab;
            }
        }
        MunicionInfo PPrefab;
        PPrefab.prefab = Instantiate(PastelazoPrefab);
        PPrefab.prefab.transform.SetParent(transform);
        PPrefab.prefab.SetActive(true);
        PPrefab.scriptPastelazoPW = PPrefab.prefab.GetComponent<PastelazoPW>();
        PPrefab.scriptPastelazoPW.ShootByPlayer = isPlayer;
        Pasteles.Add(PPrefab);

        return PPrefab.prefab;
    }
}
