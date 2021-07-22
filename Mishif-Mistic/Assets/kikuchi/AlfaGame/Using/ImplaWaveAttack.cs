using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImplaWaveAttack : MonoBehaviour
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
            this.tag = ("P" + playerID + "ImplaWaveBack");
            Invoke("Impla2Normal", 1.0f);
        }
    }
    void Impla2Normal()
    {
        this.tag = ("P" + playerID + "ImplaWave");
    }
}