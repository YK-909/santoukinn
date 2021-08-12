using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1ChooseArea : MonoBehaviour
{
    public CriAtomSource SwitchSlotLRSrc;

    private float minX = 280;
    private float maxX = 770;
    new string name = "Horizontal3";
    private bool delay = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (delay == false)
        {
            float x = Input.GetAxis("Horizontal3");
            if (x < 0)
            {
                transform.Translate(-170, 0, 0);

                //音鳴らす
                SwitchSlotLRSrc.Play();
                delay = true;
                Invoke("deceideDelay", 0.3f);
            }

            if (x > 0)
            {
                transform.Translate(170, 0, 0);

                //音鳴らす
                SwitchSlotLRSrc.Play();
                delay =true;
                Invoke("deceideDelay", 0.3f);
            }
        }

        if (transform.position.x < minX)
        {
            Vector3 temp = transform.position;
            temp.x = minX;
            transform.position = temp;
        }
        if (transform.position.x > maxX)
        {
            Vector3 temp = transform.position;
            temp.x = maxX;
            transform.position = temp;
        }
    }
    private void deceideDelay()
    {
        delay = false;
    }
}
