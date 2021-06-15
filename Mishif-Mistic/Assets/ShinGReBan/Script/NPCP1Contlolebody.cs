using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCP1Contlolebody : MonoBehaviour
{
    private NPCPlayer1body sw;
    public static int head;
    public static int body;
    public static int leg;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("1P_body");
        sw = canvas.GetComponent<NPCPlayer1body>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (sw.WeponType)
        {
            case 0:
                body = 1;
                break;

            case 1:
                body = 2;
                break;

            case 2:
                body = 3;
                break;
        }
    }

    public static int GetBody()
    {
        return body;
    }
}
