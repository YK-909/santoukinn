using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contlole : MonoBehaviour
{

    private Player1head sw;
    public static int head;
    public static int body;
    public static int leg;

    //ADX設定
    public CriAtomSource LionSlotVo;
    public CriAtomSource FrogSlotVo;
    public CriAtomSource StagSlotVo;
    //音数制限
    bool isLionVoOnce = false;
    bool isFrogVoOnce = false;
    bool isStagVoOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("1P_head");
        sw = canvas.GetComponent<Player1head>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(sw.WeponType)
        {
            case 0:
                head = 1;
                break;

            case 1:
                head = 2;
                break;
            
            case 2:
                head = 3;
                break;
        }

        //音鳴らす
        if (head == 1)
        {
            if (isFrogVoOnce == false)
            {
                isFrogVoOnce = true;
                FrogSlotVo.Play();
                isLionVoOnce = false;
                isStagVoOnce = false;
            }
        }
        if (head == 2)
        {
            if (isLionVoOnce == false)
            {
                isLionVoOnce = true;
                LionSlotVo.Play();
                isFrogVoOnce = false;
                isStagVoOnce = false;
            }
        }
        if (head == 2)
        {
            if (isStagVoOnce == false)
            {
                isStagVoOnce = true;
                StagSlotVo.Play();
                isLionVoOnce = false;
                isFrogVoOnce = false;
            }
        }
    }

    public static int GetHead()
    {
        return head;
    }
}
