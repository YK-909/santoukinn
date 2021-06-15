using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCP1Contloleleg : MonoBehaviour
{
    private NPCPlayer1leg sw;
    public static int head;
    public static int body;
    public static int leg;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("1P_leg");
        sw = canvas.GetComponent<NPCPlayer1leg>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (sw.WeponType)
        {
            case 0:
                leg = 1;
                break;

            case 1:
                leg = 2;
                break;

            case 2:
                leg = 3;
                break;
        }
    }

    public static int GetLeg()
    {
        return leg;
    }
}
