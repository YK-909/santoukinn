using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContloleBody : MonoBehaviour
{
    private Player1body sw;
    public static int head;
    public static int body;
    public static int leg;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("1P_body");
        sw = canvas.GetComponent<Player1body>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (sw.WeponType)
        {
            case 0:
                body = 1;
                Debug.Log("カメ");
                break;

            case 1:
                body = 2;
                Debug.Log("サソリ");
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
