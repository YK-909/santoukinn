using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotCinemaPlayer : MonoBehaviour
{
    public GameObject FSW;
    public GameObject LTW;
    public GameObject KAU;
    private Vector3 PlayerObject;
    private Vector3 PlayerRotate;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FSW.activeSelf)
        {
            PlayerObject = FSW.transform.position;
            PlayerRotate = FSW.transform.localEulerAngles;
        }
        else if (LTW.activeSelf)
        {
            PlayerObject = LTW.transform.position;
            PlayerRotate = LTW.transform.localEulerAngles;
        }
        else if (KAU.activeSelf)
        {
            PlayerObject = KAU.transform.position;
            PlayerRotate = KAU.transform.localEulerAngles;
        }
        this.transform.position = PlayerObject;
        this.transform.localEulerAngles=PlayerRotate;
    }
}
