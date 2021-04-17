using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContloleBody2 : MonoBehaviour
{
    private Player2body sw;
    public static int head2;
    public static int body2;
    public static int leg2;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("2P_body");
        sw = canvas.GetComponent<Player2body>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (sw.WeponType)
        {
            case 0:
                body2 = 1;
                break;

            case 1:
                body2 = 2;
                break;

            case 2:
                body2 = 3;
                break;
        }
    }

    public static int GetBody2()
    {
        return body2;
    }
}
