using System.Collections;
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
    public GameObject KAI;
    public GameObject KAU;
    public GameObject KSI;
    public GameObject KSW;
    public GameObject KSU;
    public GameObject KTI;
    public GameObject KTW;
    public GameObject KTU;
    public GameObject FSIW;
    public GameObject FSWW;
    public GameObject FSUW;
    public GameObject FTIW;
    public GameObject FTWW;
    public GameObject FTUW;
    public GameObject FAIW;
    public GameObject FAWW;
    public GameObject FAUW;
    public GameObject LSIW;
    public GameObject LSWW;
    public GameObject LSUW;
    public GameObject LTIW;
    public GameObject LTWW;
    public GameObject LTUW;
    public GameObject LAIW;
    public GameObject LAWW;
    public GameObject LAUW;
    public GameObject KAWW;
    public GameObject KAIW;
    public GameObject KAUW;
    public GameObject KSIW;
    public GameObject KSWW;
    public GameObject KSUW;
    public GameObject KTIW;
    public GameObject KTWW;
    public GameObject KTUW;
    public GameObject FSID;
    public GameObject FSWD;
    public GameObject FSUD;
    public GameObject FTID;
    public GameObject FTWD;
    public GameObject FTUD;
    public GameObject FAID;
    public GameObject FAWD;
    public GameObject FAUD;
    public GameObject LSID;
    public GameObject LSWD;
    public GameObject LSUD;
    public GameObject LTID;
    public GameObject LTWD;
    public GameObject LTUD;
    public GameObject LAID;
    public GameObject LAWD;
    public GameObject LAUD;
    public GameObject KAWD;
    public GameObject KAID;
    public GameObject KAUD;
    public GameObject KSID;
    public GameObject KSWD;
    public GameObject KSUD;
    public GameObject KTID;
    public GameObject KTWD;
    public GameObject KTUD;
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
        else if (KAI.activeSelf)
        {
            PlayerObject = KAI.transform.position;
        }
        else if (KAU.activeSelf)
        {
            PlayerObject = KAU.transform.position;
        }
        else if (KSI.activeSelf)
        {
            PlayerObject = KSI.transform.position;
        }
        else if (KSW.activeSelf)
        {
            PlayerObject = KSW.transform.position;
        }
        else if (KSU.activeSelf)
        {
            PlayerObject = KSU.transform.position;
        }
        else if (KTI.activeSelf)
        {
            PlayerObject = KTI.transform.position;
        }
        else if (KTW.activeSelf)
        {
            PlayerObject = KTW.transform.position;
        }
        else if (KTU.activeSelf)
        {
            PlayerObject = KTU.transform.position;
        }
        else if (FSIW.activeSelf)
        {
            PlayerObject = FSIW.transform.position;
        }
        else if (FSWW.activeSelf)
        {
            PlayerObject = FSWW.transform.position;
        }
        else if (FSUW.activeSelf)
        {
            PlayerObject = FSUW.transform.position;
        }
        else if (FTIW.activeSelf)
        {
            PlayerObject = FTIW.transform.position;
        }
        else if (FTWW.activeSelf)
        {
            PlayerObject = FTWW.transform.position;
        }
        else if (FTUW.activeSelf)
        {
            PlayerObject = FTUW.transform.position;
        }
        else if (FAIW.activeSelf)
        {
            PlayerObject = FAIW.transform.position;
        }
        else if (FAWW.activeSelf)
        {
            PlayerObject = FAWW.transform.position;
        }
        else if (FAUW.activeSelf)
        {
            PlayerObject = FAUW.transform.position;
        }
        else if (LSIW.activeSelf)
        {
            PlayerObject = LSIW.transform.position;
        }
        else if (LSWW.activeSelf)
        {
            PlayerObject = LSWW.transform.position;
        }
        else if (LSUW.activeSelf)
        {
            PlayerObject = LSUW.transform.position;
        }
        else if (LTIW.activeSelf)
        {
            PlayerObject = LTIW.transform.position;
        }
        else if (LTWW.activeSelf)
        {
            PlayerObject = LTWW.transform.position;
        }
        else if (LTUW.activeSelf)
        {
            PlayerObject = LTUW.transform.position;
        }
        else if (LAIW.activeSelf)
        {
            PlayerObject = LAIW.transform.position;
        }
        else if (LAWW.activeSelf)
        {
            PlayerObject = LAWW.transform.position;
        }
        else if (LAUW.activeSelf)
        {
            PlayerObject = LAUW.transform.position;
        }
        else if (KAWW.activeSelf)
        {
            PlayerObject = KAWW.transform.position;
        }
        else if (KAIW.activeSelf)
        {
            PlayerObject = KAIW.transform.position;
        }
        else if (KAUW.activeSelf)
        {
            PlayerObject = KAUW.transform.position;
        }
        else if (KSIW.activeSelf)
        {
            PlayerObject = KSIW.transform.position;
        }
        else if (KSWW.activeSelf)
        {
            PlayerObject = KSWW.transform.position;
        }
        else if (KSUW.activeSelf)
        {
            PlayerObject = KSUW.transform.position;
        }
        else if (KTIW.activeSelf)
        {
            PlayerObject = KTIW.transform.position;
        }
        else if (KTWW.activeSelf)
        {
            PlayerObject = KTWW.transform.position;
        }
        else if (KTUW.activeSelf)
        {
            PlayerObject = KTUW.transform.position;
        }
        else if (FSID.activeSelf)
        {
            PlayerObject = FSID.transform.position;
        }
        else if (FSWD.activeSelf)
        {
            PlayerObject = FSWD.transform.position;
        }
        else if (FSUD.activeSelf)
        {
            PlayerObject = FSUD.transform.position;
        }
        else if (FTID.activeSelf)
        {
            PlayerObject = FTID.transform.position;
        }
        else if (FTWD.activeSelf)
        {
            PlayerObject = FTWD.transform.position;
        }
        else if (FTUD.activeSelf)
        {
            PlayerObject = FTUD.transform.position;
        }
        else if (FAID.activeSelf)
        {
            PlayerObject = FAID.transform.position;
        }
        else if (FAWD.activeSelf)
        {
            PlayerObject = FAWD.transform.position;
        }
        else if (FAUD.activeSelf)
        {
            PlayerObject = FAUD.transform.position;
        }
        else if (LSID.activeSelf)
        {
            PlayerObject = LSID.transform.position;
        }
        else if (LSWD.activeSelf)
        {
            PlayerObject = LSWD.transform.position;
        }
        else if (LSUD.activeSelf)
        {
            PlayerObject = LSUD.transform.position;
        }
        else if (LTID.activeSelf)
        {
            PlayerObject = LTID.transform.position;
        }
        else if (LTWD.activeSelf)
        {
            PlayerObject = LTWD.transform.position;
        }
        else if (LTUD.activeSelf)
        {
            PlayerObject = LTUD.transform.position;
        }
        else if (LAID.activeSelf)
        {
            PlayerObject = LAID.transform.position;
        }
        else if (LAWD.activeSelf)
        {
            PlayerObject = LAWD.transform.position;
        }
        else if (LAUD.activeSelf)
        {
            PlayerObject = LAUD.transform.position;
        }
        else if (KAWD.activeSelf)
        {
            PlayerObject = KAWD.transform.position;
        }
        else if (KAID.activeSelf)
        {
            PlayerObject = KAID.transform.position;
        }
        else if (KAUD.activeSelf)
        {
            PlayerObject = KAUD.transform.position;
        }
        else if (KSID.activeSelf)
        {
            PlayerObject = KSID.transform.position;
        }
        else if (KSWD.activeSelf)
        {
            PlayerObject = KSWD.transform.position;
        }
        else if (KSUD.activeSelf)
        {
            PlayerObject = KSUD.transform.position;
        }
        else if (KTID.activeSelf)
        {
            PlayerObject = KTID.transform.position;
        }
        else if (KTWD.activeSelf)
        {
            PlayerObject = KTWD.transform.position;
        }
        else if (KTUD.activeSelf)
        {
            PlayerObject = KTUD.transform.position;
        }
        this.transform.position = PlayerObject;
    }
}
