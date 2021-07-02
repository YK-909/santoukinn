using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADX_SlotUD_CuePlay : MonoBehaviour
{
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
        //上
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            atomSrc.Play();
        }
        //下
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            atomSrc.Play();
        }
    }
}
