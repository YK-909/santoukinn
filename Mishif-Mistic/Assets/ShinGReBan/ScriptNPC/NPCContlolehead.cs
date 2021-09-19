using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCContlolehead : MonoBehaviour
{
    private NPChead sw;
    public static int head2;

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
        GameObject canvas = GameObject.Find("2P_head");
        sw = canvas.GetComponent<NPChead>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (sw.WeponType)
        {
            case 0:
                head2 = 1;
                break;

            case 1:
                head2 = 2;
                break;

            case 2:
                head2 = 3;
                break;
        }

        //音鳴らす
        if (head2 == 1)
        {
            if (!isFrogVoOnce)
            {
                isFrogVoOnce = true;
                FrogSlotVo.Play();
                isLionVoOnce = false;
                isStagVoOnce = false;
            }
            
        }
        if (head2 == 2)
        {
            if (!isLionVoOnce)
            {
                isLionVoOnce = true;
                LionSlotVo.Play();
                isFrogVoOnce = false;
                isStagVoOnce = false;
            }
        }
        if (head2 == 3)
        {
            if (isStagVoOnce == false)
            {
                isStagVoOnce = true;
                StagSlotVo.Play();
                isFrogVoOnce = false;
                isLionVoOnce = false;
            }
        }
    }

    public static int GetHead2()
    {
        return head2;
    }
}
