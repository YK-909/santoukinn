﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCP1Contlolehead : MonoBehaviour
{
    private NPCPlayer1head sw;
    public static int head;
    public static int body;
    public static int leg;

    //ADX設定
    public CriAtomSource LionSlotVo;
    public CriAtomSource FrogSlotVo;
    //音数制限
    bool isLionVoOnce = false;
    bool isFrogVoOnce = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("1P_head");
        sw = canvas.GetComponent<NPCPlayer1head>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (sw.WeponType)
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
            }

        }
        if (head == 2)
        {
            if (isLionVoOnce == false)
            {
                isLionVoOnce = true;
                LionSlotVo.Play();
                isFrogVoOnce = false;
            }
        }
    }

    public static int GetHead()
    {
        return head;
    }
}