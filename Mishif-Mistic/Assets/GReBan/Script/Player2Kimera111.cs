using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Kimera111 : MonoBehaviour
{
    [SerializeField]
    int Head2;
    [SerializeField]
    int Body2;
    [SerializeField]
    int Leg2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Contlole2.GetHead2() == 1 && ContloleBody2.GetBody2() == 1 && ContloleLeg2.GetLeg2() == 1)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
