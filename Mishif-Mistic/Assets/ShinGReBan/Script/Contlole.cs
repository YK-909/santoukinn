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
            FrogSlotVo.Play();
        }
        if (head == 2)
        {
            LionSlotVo.Play();
        }
    }

    public static int GetHead()
    {
        return head;
    }
}
