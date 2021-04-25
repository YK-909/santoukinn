using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlogAttack : MonoBehaviour
{
    public int playerID = 1;
    public GameObject FlogCouter;
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
            FlogCouter.tag = ("P" + playerID + "FlogAttackBack");
            Invoke("FlogNormal", 1.0f);
        }
    }
    void FlogNormal()
    {
        this.tag = ("Player" + playerID );
    }
}