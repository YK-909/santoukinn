using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contlole : MonoBehaviour
{

    private Player1head sw;
    public static int head;
    public static int body;
    public static int leg;

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
                Debug.Log("カエル");
                break;

            case 1:
                head = 2;
                Debug.Log("ライオン");
                break;
            
            case 2:
                head = 3;
                Debug.Log("Kim3");
                break;
        }
    }

    public static int GetHead()
    {
        return head;
    }
}
