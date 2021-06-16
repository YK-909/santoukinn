using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1Kimera : MonoBehaviour
{
    [SerializeField]
    int Head;
    [SerializeField]
    int Body;
    [SerializeField]
    int Leg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Contlole.GetHead() == Head && ContloleBody.GetBody() == Body && ContloleLeg.GetLeg() == Leg)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
