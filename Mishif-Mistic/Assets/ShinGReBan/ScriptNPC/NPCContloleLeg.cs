using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCContloleLeg : MonoBehaviour
{
    private NPCleg sw;
    public static int head2;
    public static int body2;
    public static int leg2;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("2P_leg");
        sw = canvas.GetComponent<NPCleg>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (sw.WeponType)
        {
            case 0:
                leg2 = 2;
                break;

            case 1:
                leg2 = 2;
                break;

            case 2:
                leg2 = 2;
                break;
        }
    }

    public static int GetLeg2()
    {
        return leg2;
    }
}
