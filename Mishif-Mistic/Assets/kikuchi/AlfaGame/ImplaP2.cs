using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImplaP2 : MonoBehaviour
{
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
            this.tag = "P2ImplaBack";
            Invoke("ImplaNormal", 1.0f);
        }
    }
    void ImplaNormal() 
    {
        this.tag = "P2Impla";
    }
}
