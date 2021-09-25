using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCKimera : MonoBehaviour
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
        if (EnemySelectButton.GetHead2() == Head2 && EnemySelectButton.GetBody2() == Body2 && EnemySelectButton.GetLeg2() == Leg2)
        {
            this.gameObject.SetActive(true);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }
}
