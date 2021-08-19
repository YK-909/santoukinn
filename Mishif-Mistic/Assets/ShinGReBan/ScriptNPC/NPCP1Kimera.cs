using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCP1Kimera : MonoBehaviour
{
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
        if (NPCP1Contlolehead.GetHead() == Head && NPCP1Contlolebody.GetBody() == Body && NPCP1Contloleleg.GetLeg() == Leg&& NPCP1ContlolePassive.GetPassive()==Passive)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
