﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemaPlayer : MonoBehaviour
{
    public GameObject FSI;
    public GameObject FSW;
    public GameObject FSU;
    public GameObject FTI;
    public GameObject FTW;
    public GameObject FTU;
    public GameObject FAI;
    public GameObject FAW;
    public GameObject FAU;
    public GameObject LSI;
    public GameObject LSW;
    public GameObject LSU;
    public GameObject LTI;
    public GameObject LTW;
    public GameObject LTU;
    public GameObject LAI;
    public GameObject LAW;
    public GameObject LAU;
    public GameObject KAW;

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
        else if (FSU.activeSelf)
        {
            PlayerObject = FSU.transform.position;
        }
        else if (FTI.activeSelf)
        {
            PlayerObject = FTI.transform.position;
        }
        else if (FTW.activeSelf)
        {
            PlayerObject = FTW.transform.position;
        }
        else if (FTU.activeSelf)
        {
            PlayerObject = FTU.transform.position;
        }
        else if (FAI.activeSelf)
        {
            PlayerObject = FAI.transform.position;
        }
        else if (FAW.activeSelf)
        {
            PlayerObject = FAW.transform.position;
        }
        else if (FAU.activeSelf)
        {
            PlayerObject = FAU.transform.position;
        }
        else if (LSI.activeSelf)
        {
            PlayerObject = LSI.transform.position;
        }
        else if (LSW.activeSelf)
        {
            PlayerObject = LSW.transform.position;
        }
        else if (LSU.activeSelf)
        {
            PlayerObject = LSU.transform.position;
        }
        else if (LTI.activeSelf)
        {
            PlayerObject = LTI.transform.position;
        }
        else if (LTW.activeSelf)
        {
            PlayerObject = LTW.transform.position;
        }
        else if (LTU.activeSelf)
        {
            PlayerObject = LTU.transform.position;
        }
        else if (LAI.activeSelf)
        {
            PlayerObject = LAI.transform.position;
        }
        else if (LAW.activeSelf)
        {
            PlayerObject = LAW.transform.position;
        }
        else if (LAU.activeSelf)
        {
            PlayerObject = LAU.transform.position;
        }
        else if (KAW.activeSelf)
        {
            PlayerObject = KAW.transform.position;
        }
        this.transform.position = PlayerObject;
    }
}