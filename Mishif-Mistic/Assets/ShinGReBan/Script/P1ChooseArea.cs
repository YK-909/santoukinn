using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1ChooseArea : MonoBehaviour
{
    public CriAtomSource SwitchSlotLRSrc;

    private float minX = 270;
    private float maxX = 680;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Joystick2Button0))
        {
            transform.Translate(-200, 0, 0);

            //音鳴らす
            SwitchSlotLRSrc.Play();
        }

        if (Input.GetKey(KeyCode.Joystick2Button3))
        {
            transform.Translate(200, 0, 0);

            //音鳴らす
            SwitchSlotLRSrc.Play();
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
}
