using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseArea : MonoBehaviour
{
    //ADX設定
    public CriAtomSource KeyboardSlotLRSrc;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-160, 0, 0);

            //音鳴らす
            KeyboardSlotLRSrc.Play();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(160, 0, 0);

            //音鳴らす
            KeyboardSlotLRSrc.Play();
        }
    }
}
