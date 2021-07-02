using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ADX_GardenBGM_CuePlay : MonoBehaviour
{
    public CriAtomSource BGMSrc;
    string cueSheetBGM = "GardenBGM";

    // Start is called before the first frame update
    void Start()
    {
        BGMSrc = (CriAtomSource)GetComponent("CriAtomSource");
        CriAtomExAcb BGMacb = CriAtom.GetAcb(cueSheetBGM);
        BGMSrc.cueSheet = cueSheetBGM;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
