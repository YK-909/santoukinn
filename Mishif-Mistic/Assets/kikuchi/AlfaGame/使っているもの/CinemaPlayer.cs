﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemaPlayer : MonoBehaviour
{
    public GameObject FSI;
    public GameObject FSW;
    public GameObject FTI;
    public GameObject FTW;
    public GameObject LSI;
    public GameObject LSW;
    public GameObject LTI;
    public GameObject LTW;
    public GameObject KAW;
    public GameObject LTU;

    private Vector3 PlayerObject;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (FSI.activeSelf)
        {
            PlayerObject = FSI.transform.position;
        }
        else if (FSW.activeSelf)
        {
            PlayerObject = FSW.transform.position;
        }
        else if (FTI.activeSelf)
        {
            PlayerObject = FTI.transform.position;
        }
        else if (FTW.activeSelf)
        {
            PlayerObject = FTW.transform.position;
        }
        else if (LSI.activeSelf)
        {
            PlayerObject = LSI.transform.position;
        }
        else if (LSW.activeSelf)
        {
            PlayerObject = LSW.transform.position;
        }
        else if (LTI.activeSelf)
        {
            PlayerObject = LTI.transform.position;
        }
        else if (LTW.activeSelf)
        {
            PlayerObject = LTW.transform.position;
        }
        else if (KAW.activeSelf)
        {
            PlayerObject = LTW.transform.position;
        }
        else if (LTU.activeSelf)
        {
            PlayerObject = LTW.transform.position;
        }
        this.transform.position = PlayerObject;
    }
}
