using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlogAttack : MonoBehaviour
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
            this.tag = ("P" + playerID + "FlogAttackBack");
            Invoke("FlogNormal", 1.5f);
        }
    }
    void FlogNormal()
    {
        this.tag = ("Player" + playerID );
    }
}