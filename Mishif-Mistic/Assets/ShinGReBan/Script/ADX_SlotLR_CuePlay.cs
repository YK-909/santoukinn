using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADX_SlotLR_CuePlay : MonoBehaviour
{
    //ADX設定
    private CriAtomSource atomSrc;

    // Start is called before the first frame update
    void Start()
    {
        //CriAtomSourceを取得
        atomSrc = (CriAtomSource)GetComponent("CriAtomSource");
    }

    // Update is called once per frame
    void Update()
    {
        //左傾き1P
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            //音鳴らす
            atomSrc.Play();
        }
        //右傾きIP
        else if (0 < Input.GetAxisRaw("Horizontal"))
        {
            //音鳴らす
            atomSrc.Play();
        }
        //左2P
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //音鳴らす
            atomSrc.Play();
        }
        //右2P
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //音鳴らす
            atomSrc.Play();
        }
    }
}
