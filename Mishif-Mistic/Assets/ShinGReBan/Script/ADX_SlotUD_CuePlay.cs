using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADX_SlotUD_CuePlay : MonoBehaviour
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
        //左2P
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //音鳴らす
            atomSrc.Play();
        }
        //右2P
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //音鳴らす
            atomSrc.Play();
        }
        //上傾き
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            //音鳴らす
            atomSrc.Play();
        }
        //下傾き
        else if (0 < Input.GetAxisRaw("Vertical"))
        {
            //音鳴らす
            atomSrc.Play();
        }
    }
}
