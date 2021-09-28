using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_finish : MonoBehaviour
{
    public GameObject VolumeUI;
    //ADX設定
    public CriAtomSource BGMSrc;
    public CriAtomSource ESSrc;
    string cueSheetBGM = "GardenBGM";
    public string cueSheetES;
    // Start is called before the first frame update
    void Start()
    {
        //CriAtomSource取得
        CriAtomExAcb BGMacb = CriAtom.GetAcb(cueSheetBGM);
        BGMSrc.cueSheet = cueSheetBGM;
        ESSrc.cueSheet = cueSheetES;
    }

    // Update is called once per frame
    void Update()
    {
        if (VolumeUI.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                VolumeUI.SetActive(false);
            }
        }
    }
    public void Soundfinish()
    {
        //再開
        BGMSrc.Pause(false);
        ESSrc.Pause(false);

        VolumeUI.SetActive(false);
    }
}
