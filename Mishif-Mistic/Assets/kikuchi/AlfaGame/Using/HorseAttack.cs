using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseAttack : MonoBehaviour
{
    public int playerID = 1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Gard"))
        {
            this.tag = ("P" + playerID + "HorseAttackBack");
            Invoke("HorseNormal", 1.0f);
        }
    }
    void HorseNormal()
    {
        this.tag = ("P" + playerID + "HorseAttack");
    }
}
