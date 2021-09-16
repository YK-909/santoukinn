using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalsyBlockP1 : MonoBehaviour
{
    private float Timecount = 0;
    private bool Once = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Timecount += Time.deltaTime;
        if (Timecount < 2.0)
        {
            this.transform.localScale = new Vector3(this.transform.localScale.x, this.transform.localScale.y, transform.localScale.z + 25f * Time.deltaTime);
        }
        if (Timecount > 7.0)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player2")
        {
            Invoke("DelayPala", 0.1f);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag != "PalsyBullet1" && collision.gameObject.tag != "Player1")
        {
            if (Once == true)
            {
                Timecount = 2;
                Once = false;
            }
        }
    }
    private void DelayPala()
    {
        Destroy(this);
    }
}