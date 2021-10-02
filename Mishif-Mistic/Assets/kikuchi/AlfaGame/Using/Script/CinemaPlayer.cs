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
    private Vector3 PlayerRotate;
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (FSI.activeSelf)
        {
            PlayerObject = FSI.transform.position;
            PlayerRotate = FSI.transform.localEulerAngles;
        }
        else if (FSW.activeSelf)
        {
            PlayerObject = FSW.transform.position;
            PlayerRotate = FSW.transform.localEulerAngles;
        }
        else if (FSU.activeSelf)
        {
            PlayerObject = FSU.transform.position;
            PlayerRotate = FSU.transform.localEulerAngles;
        }
        else if (FTI.activeSelf)
        {
            PlayerObject = FTI.transform.position;
            PlayerRotate = FTI.transform.localEulerAngles;
        }
        else if (FTW.activeSelf)
        {
            PlayerObject = FTW.transform.position;
            PlayerRotate = FTW.transform.localEulerAngles;
        }
        else if (FTU.activeSelf)
        {
            PlayerObject = FTU.transform.position;
            PlayerRotate = FTU.transform.localEulerAngles;
        }
        else if (FAI.activeSelf)
        {
            PlayerObject = FAI.transform.position;
            PlayerRotate = FAI.transform.localEulerAngles;
        }
        else if (FAW.activeSelf)
        {
            PlayerObject = FAW.transform.position;
            PlayerRotate = FAW.transform.localEulerAngles;
        }
        else if (FAU.activeSelf)
        {
            PlayerObject = FAU.transform.position;
            PlayerRotate = FAU.transform.localEulerAngles;
        }
        else if (LSI.activeSelf)
        {
            PlayerObject = LSI.transform.position;
            PlayerRotate = LSI.transform.localEulerAngles;
        }
        else if (LSW.activeSelf)
        {
            PlayerObject = LSW.transform.position;
            PlayerRotate = LSW.transform.localEulerAngles;
        }
        else if (LSU.activeSelf)
        {
            PlayerObject = LSU.transform.position;
            PlayerRotate = LSU.transform.localEulerAngles;
        }
        else if (LTI.activeSelf)
        {
            PlayerObject = LTI.transform.position;
            PlayerRotate = LTI.transform.localEulerAngles;
        }
        else if (LTW.activeSelf)
        {
            PlayerObject = LTW.transform.position;
            PlayerRotate = LTW.transform.localEulerAngles;
        }
        else if (LTU.activeSelf)
        {
            PlayerObject = LTU.transform.position;
            PlayerRotate = LTU.transform.localEulerAngles;
        }
        else if (LAI.activeSelf)
        {
            PlayerObject = LAI.transform.position;
            PlayerRotate = LAI.transform.localEulerAngles;
        }
        else if (LAW.activeSelf)
        {
            PlayerObject = LAW.transform.position;
            PlayerRotate = LAW.transform.localEulerAngles;
        }
        else if (LAU.activeSelf)
        {
            PlayerObject = LAU.transform.position;
            PlayerRotate = LAU.transform.localEulerAngles;
        }
        else if (KAW.activeSelf)
        {
            PlayerObject = KAW.transform.position;
            PlayerRotate = KAW.transform.localEulerAngles;
        }
        else if (KAI.activeSelf)
        {
            PlayerObject = KAI.transform.position;
            PlayerRotate = KAI.transform.localEulerAngles;
        }
        else if (KAU.activeSelf)
        {
            PlayerObject = KAU.transform.position;
            PlayerRotate = KAU.transform.localEulerAngles;
        }
        else if (KSI.activeSelf)
        {
            PlayerObject = KSI.transform.position;
            PlayerRotate = KSI.transform.localEulerAngles;
        }
        else if (KSW.activeSelf)
        {
            PlayerObject = KSW.transform.position;
            PlayerRotate = KSW.transform.localEulerAngles;
        }
        else if (KSU.activeSelf)
        {
            PlayerObject = KSU.transform.position;
            PlayerRotate = KSU.transform.localEulerAngles;
        }
        else if (KTI.activeSelf)
        {
            PlayerObject = KTI.transform.position;
            PlayerRotate = KTI.transform.localEulerAngles;
        }
        else if (KTW.activeSelf)
        {
            PlayerObject = KTW.transform.position;
            PlayerRotate = KTW.transform.localEulerAngles;
        }
        else if (KTU.activeSelf)
        {
            PlayerObject = KTU.transform.position;
            PlayerRotate = KTU.transform.localEulerAngles;
        }
        else if (FSIW.activeSelf)
        {
            PlayerObject = FSIW.transform.position;
            PlayerRotate = FSIW.transform.localEulerAngles;
        }
        else if (FSWW.activeSelf)
        {
            PlayerObject = FSWW.transform.position;
            PlayerRotate = FSWW.transform.localEulerAngles;
        }
        else if (FSUW.activeSelf)
        {
            PlayerObject = FSUW.transform.position;
            PlayerRotate = FSUW.transform.localEulerAngles;
        }
        else if (FTIW.activeSelf)
        {
            PlayerObject = FTIW.transform.position;
            PlayerRotate = FTIW.transform.localEulerAngles;
        }
        else if (FTWW.activeSelf)
        {
            PlayerObject = FTWW.transform.position;
            PlayerRotate = FTWW.transform.localEulerAngles;
        }
        else if (FTUW.activeSelf)
        {
            PlayerObject = FTUW.transform.position;
            PlayerRotate = FTUW.transform.localEulerAngles;
        }
        else if (FAIW.activeSelf)
        {
            PlayerObject = FAIW.transform.position;
            PlayerRotate = FAIW.transform.localEulerAngles;
        }
        else if (FAWW.activeSelf)
        {
            PlayerObject = FAWW.transform.position;
            PlayerRotate = FAWW.transform.localEulerAngles;
        }
        else if (FAUW.activeSelf)
        {
            PlayerObject = FAUW.transform.position;
            PlayerRotate = FAUW.transform.localEulerAngles;
        }
        else if (LSIW.activeSelf)
        {
            PlayerObject = LSIW.transform.position;
            PlayerRotate = LSIW.transform.localEulerAngles;
        }
        else if (LSWW.activeSelf)
        {
            PlayerObject = LSWW.transform.position;
            PlayerRotate = LSWW.transform.localEulerAngles;
        }
        else if (LSUW.activeSelf)
        {
            PlayerObject = LSUW.transform.position;
            PlayerRotate = LSUW.transform.localEulerAngles;
        }
        else if (LTIW.activeSelf)
        {
            PlayerObject = LTIW.transform.position;
            PlayerRotate = LTIW.transform.localEulerAngles;
        }
        else if (LTWW.activeSelf)
        {
            PlayerObject = LTWW.transform.position;
            PlayerRotate = LTWW.transform.localEulerAngles;
        }
        else if (LTUW.activeSelf)
        {
            PlayerObject = LTUW.transform.position;
            PlayerRotate = LTUW.transform.localEulerAngles;
        }
        else if (LAIW.activeSelf)
        {
            PlayerObject = LAIW.transform.position;
            PlayerRotate = LAIW.transform.localEulerAngles;
        }
        else if (LAWW.activeSelf)
        {
            PlayerObject = LAWW.transform.position;
            PlayerRotate = LAWW.transform.localEulerAngles;
        }
        else if (LAUW.activeSelf)
        {
            PlayerObject = LAUW.transform.position;
            PlayerRotate = LAUW.transform.localEulerAngles;
        }
        else if (KAWW.activeSelf)
        {
            PlayerObject = KAWW.transform.position;
            PlayerRotate = KAWW.transform.localEulerAngles;
        }
        else if (KAIW.activeSelf)
        {
            PlayerObject = KAIW.transform.position;
            PlayerRotate = KAIW.transform.localEulerAngles;
        }
        else if (KAUW.activeSelf)
        {
            PlayerObject = KAUW.transform.position;
            PlayerRotate = KAUW.transform.localEulerAngles;
        }
        else if (KSIW.activeSelf)
        {
            PlayerObject = KSIW.transform.position;
            PlayerRotate = KSIW.transform.localEulerAngles;
        }
        else if (KSWW.activeSelf)
        {
            PlayerObject = KSWW.transform.position;
            PlayerRotate = KSWW.transform.localEulerAngles;
        }
        else if (KSUW.activeSelf)
        {
            PlayerObject = KSUW.transform.position;
            PlayerRotate = KSUW.transform.localEulerAngles;
        }
        else if (KTIW.activeSelf)
        {
            PlayerObject = KTIW.transform.position;
            PlayerRotate = KTIW.transform.localEulerAngles;
        }
        else if (KTWW.activeSelf)
        {
            PlayerObject = KTWW.transform.position;
            PlayerRotate = KTWW.transform.localEulerAngles;
        }
        else if (KTUW.activeSelf)
        {
            PlayerObject = KTUW.transform.position;
            PlayerRotate = KTUW.transform.localEulerAngles;
        }
        else if (FSID.activeSelf)
        {
            PlayerObject = FSID.transform.position;
            PlayerRotate = FSID.transform.localEulerAngles;
        }
        else if (FSWD.activeSelf)
        {
            PlayerObject = FSWD.transform.position;
            PlayerRotate = FSWD.transform.localEulerAngles;
        }
        else if (FSUD.activeSelf)
        {
            PlayerObject = FSUD.transform.position;
            PlayerRotate = FSUD.transform.localEulerAngles;
        }
        else if (FTID.activeSelf)
        {
            PlayerObject = FTID.transform.position;
            PlayerRotate = FTID.transform.localEulerAngles;
        }
        else if (FTWD.activeSelf)
        {
            PlayerObject = FTWD.transform.position;
            PlayerRotate = FTWD.transform.localEulerAngles;
        }
        else if (FTUD.activeSelf)
        {
            PlayerObject = FTUD.transform.position;
            PlayerRotate = FTUD.transform.localEulerAngles;
        }
        else if (FAID.activeSelf)
        {
            PlayerObject = FAID.transform.position;
            PlayerRotate = FAID.transform.localEulerAngles;
        }
        else if (FAWD.activeSelf)
        {
            PlayerObject = FAWD.transform.position;
            PlayerRotate = FAWD.transform.localEulerAngles;
        }
        else if (FAUD.activeSelf)
        {
            PlayerObject = FAUD.transform.position;
            PlayerRotate = FAUD.transform.localEulerAngles;
        }
        else if (LSID.activeSelf)
        {
            PlayerObject = LSID.transform.position;
            PlayerRotate = LSID.transform.localEulerAngles;
        }
        else if (LSWD.activeSelf)
        {
            PlayerObject = LSWD.transform.position;
            PlayerRotate = LSWD.transform.localEulerAngles;
        }
        else if (LSUD.activeSelf)
        {
            PlayerObject = LSUD.transform.position;
            PlayerRotate = LSUD.transform.localEulerAngles;
        }
        else if (LTID.activeSelf)
        {
            PlayerObject = LTID.transform.position;
            PlayerRotate = LTID.transform.localEulerAngles;
        }
        else if (LTWD.activeSelf)
        {
            PlayerObject = LTWD.transform.position;
            PlayerRotate = LTWD.transform.localEulerAngles;
        }
        else if (LTUD.activeSelf)
        {
            PlayerObject = LTUD.transform.position;
            PlayerRotate = LTUD.transform.localEulerAngles;
        }
        else if (LAID.activeSelf)
        {
            PlayerObject = LAID.transform.position;
            PlayerRotate = LAID.transform.localEulerAngles;
        }
        else if (LAWD.activeSelf)
        {
            PlayerObject = LAWD.transform.position;
            PlayerRotate = LAWD.transform.localEulerAngles;
        }
        else if (LAUD.activeSelf)
        {
            PlayerObject = LAUD.transform.position;
            PlayerRotate = LAUD.transform.localEulerAngles;
        }
        else if (KAWD.activeSelf)
        {
            PlayerObject = KAWD.transform.position;
            PlayerRotate = KAWD.transform.localEulerAngles;
        }
        else if (KAID.activeSelf)
        {
            PlayerObject = KAID.transform.position;
            PlayerRotate = KAID.transform.localEulerAngles;
        }
        else if (KAUD.activeSelf)
        {
            PlayerObject = KAUD.transform.position;
            PlayerRotate = KAUD.transform.localEulerAngles;
        }
        else if (KSID.activeSelf)
        {
            PlayerObject = KSID.transform.position;
            PlayerRotate = KSID.transform.localEulerAngles;
        }
        else if (KSWD.activeSelf)
        {
            PlayerObject = KSWD.transform.position;
            PlayerRotate = KSWD.transform.localEulerAngles;
        }
        else if (KSUD.activeSelf)
        {
            PlayerObject = KSUD.transform.position;
            PlayerRotate = KSUD.transform.localEulerAngles;
        }
        else if (KTID.activeSelf)
        {
            PlayerObject = KTID.transform.position;
            PlayerRotate = KTID.transform.localEulerAngles;
        }
        else if (KTWD.activeSelf)
        {
            PlayerObject = KTWD.transform.position;
            PlayerRotate = KTWD.transform.localEulerAngles;
        }
        else if (KTUD.activeSelf)
        {
            PlayerObject = KTUD.transform.position;
            PlayerRotate = KTUD.transform.localEulerAngles;
        }
        this.transform.position = PlayerObject;
        this.transform.localEulerAngles = PlayerRotate;
    }
}
