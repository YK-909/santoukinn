using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADX_SlotLR_CuePlay : MonoBehaviour
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
        //1P左
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            atomSrc.Play();
        }
        //1P右
        else if (0 < Input.GetAxisRaw("Horizontal"))
        {
            atomSrc.Play();
        }
        //2P左
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            atomSrc.Play("SlotLeftRight");
        }
        //2P右
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            atomSrc.Play("SlotLeftRight");
        }
    }
}
