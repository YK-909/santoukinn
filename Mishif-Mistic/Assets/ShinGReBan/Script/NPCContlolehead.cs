using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCContlolehead : MonoBehaviour
{
    private NPChead sw;
    public static int head2;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("2P_head");
        sw = canvas.GetComponent<NPChead>();
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
                head2 = 1;
                break;

            case 2:
                head2 = 1;
                break;
        }
    }

    public static int GetHead2()
    {
        return head2;
    }
}
