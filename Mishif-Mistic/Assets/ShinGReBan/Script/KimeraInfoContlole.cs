using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KimeraInfoContlole : MonoBehaviour
{
    public GameObject KimeraInfo;

    [SerializeField]
    int Head;
    [SerializeField]
    int Body;
    [SerializeField]
    int Leg;
    [SerializeField]
    int Passive;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (NPCP1Contlolehead.head == Head && NPCP1Contlolebody.body == Body && NPCP1Contloleleg.leg == Leg && NPCP1ContlolePassive.passive == Passive)
        {
            KimeraInfo.SetActive(true);
        }
        else
        {
            KimeraInfo.SetActive(false);
        }
    }
}
