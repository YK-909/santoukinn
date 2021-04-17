using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionAttack : MonoBehaviour
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
            this.tag = (playerID +"LionAttackBack" );
            Invoke("LionNormal", 1.0f);
        }
    }
    void LionNormal()
    {
        this.tag = (playerID + "LionAttack");
    }
}
