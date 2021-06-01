using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1ChooseArea : MonoBehaviour
{
    public CriAtomSource SwitchSlotLRSrc;

    // Start is called before the first frame update
    void Start()
    {
        var h1 = Input.GetAxis("Horizontal1");
        var v1 = Input.GetAxis("Vertical1");

        var h2 = Input.GetAxis("Horizontal2");
        var v2 = Input.GetAxis("Vertical2");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(-160, 0, 0);

            //音鳴らす
            SwitchSlotLRSrc.Play();
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(160, 0, 0);

            //音鳴らす
            SwitchSlotLRSrc.Play();
        }
    }
}
