using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImplaAttack : MonoBehaviour
{
    public int playerID = 1;
    public Collider Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
            Player.isTrigger = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        Player.isTrigger = false;
        if (other.gameObject.CompareTag("Gard"))
        {
            this.tag = ("P" + playerID + "ImplaBack");
            Invoke("ImplaNormal", 1.0f);
        }
    }
    void ImplaNormal()
    {
        this.tag = ("P" + playerID + "Impla");
    }
}
