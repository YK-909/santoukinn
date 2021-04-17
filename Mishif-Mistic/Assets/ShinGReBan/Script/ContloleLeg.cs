using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContloleLeg : MonoBehaviour
{
    private Player1leg sw;
    public static int head;
    public static int body;
    public static int leg;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("1P_leg");
        sw = canvas.GetComponent<Player1leg>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (sw.WeponType)
        {
            case 0:
                leg = 1;
                Debug.Log("Kim6");
                break;

            case 1:
                leg = 2;
                Debug.Log("Kim7");
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
