using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContlolePassive2 : MonoBehaviour
{
    private Player2passive sw;
    public static int passive2;

    // Start is called before the first frame update
    void Start()
    {
        GameObject canvas = GameObject.Find("2P_passive");
        sw = canvas.GetComponent<Player2passive>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (sw.WeponType)
        {
            case 0:
                passive2 = 1;
                break;

            case 1:
                passive2 = 2;
                break;

            case 2:
                passive2 = 3;
                break;
        }
    }

    public static int GetPassive2()
    {
        return passive2;
    }
}
