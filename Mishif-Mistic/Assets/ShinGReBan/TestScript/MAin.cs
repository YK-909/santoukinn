using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            GetComponent<BoxCollider>().enabled = false;
            Invoke("Speed", 1.5f);
        }
    }

    public void Speed()
    {
        GetComponent<BoxCollider>().enabled = true;
    }
}
