using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contlole2 : MonoBehaviour
{
    private Player2head sw;
    public static int head2;
    public static int body2;
    public static int leg2;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("2P_head");
        sw = canvas.GetComponent<Player2head>();
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
    }

    public static int GetHead2()
    {
        return head2;
    }
}
