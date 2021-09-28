using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_finish : MonoBehaviour
{
    public GameObject PauseUI;
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
        
    }
    public void Pausefinish()
    {
        //再開
        BGMSrc.Pause(false);
        ESSrc.Pause(false);

        PauseUI.SetActive(false);
    }
}
