using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseArea : MonoBehaviour
{
    //ADX設定
    public CriAtomSource KeyboardSlotLRSrc;

    private float minX = 1230;
    private float maxX = 1650;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Translate(-200, 0, 0);

            //音鳴らす
            KeyboardSlotLRSrc.Play();
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.Translate(200, 0, 0);

            //音鳴らす
            KeyboardSlotLRSrc.Play();
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
