using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalsyBulletP2 : MonoBehaviour
{
    private float Timecount = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timecount += Time.deltaTime;
        transform.position += transform.forward * 25f * Time.deltaTime;
        if (Timecount > 2.0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag =="floor")
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.tag == "Player1")
        {
            Invoke("DelayPala", 0.1f);
        }
    }
    private void DelayPala()
    {
        Destroy(this);
    }
}
