using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timerbotgame : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    private float Second = 180;
    [SerializeField]
    private Text _textCountdown;
    public static int GameChange;
    [SerializeField]
    private Text GameWinner;

    //ADX設定
    public CriAtomSource CountSrc;
    public CriAtomSource BGMSrc;
    string cueSheetBGM = "GardenBGM";
    string cueSheetCount = "CountDownSE";

    // Start is called before the first frame update
    void Start()
    {
        GameChange = 2;
        _textCountdown.text = "";
        GameWinner.text = "";
        StartCoroutine(CountdownCoroutine());

        //CriAtomSourceを取得
        CriAtomExAcb BGMacb = CriAtom.GetAcb(cueSheetBGM);
        CriAtomExAcb Countacb = CriAtom.GetAcb(cueSheetCount);
        BGMSrc.cueSheet = cueSheetBGM;
        CountSrc.cueSheet = cueSheetCount;
    }

    IEnumerator CountdownCoroutine()
    {
        _textCountdown.gameObject.SetActive(true);

        _textCountdown.text = "3";
        yield return new WaitForSeconds(1.0f);


        _textCountdown.text = "2";
        //SingleCue.Play();
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "1";
        //SingleCue.Play();
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "GO!";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "";
        _textCountdown.gameObject.SetActive(false);
        GameChange = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameChange == 1)
        {
            Second -= Time.deltaTime;
            TimerText.text = Second.ToString("f0");

            //HPが０による勝敗
            if (KeyBordPlay1.GetP1HP() <= 0)
            {
                GameWinner.text = "P2の勝利";
                GameChange = 2;

            }
            else if (BotFSW.GetP2HP() <= 0)
            {
                GameWinner.text = "P1の勝利";
                GameChange = 2;

            }
            //制限時間による勝敗
            if (Second <= 0)
            {
                if (BotFSW.GetP2HP() < KeyBordPlay1.GetP1HP())
                {
                    GameWinner.text = "P1の勝利";
                    GameChange = 2;

                }
                else if (KeyBordPlay1.GetP1HP() < BotFSW.GetP2HP())
                {
                    GameWinner.text = "P2の勝利";
                    GameChange = 2;

                }
            }
        }

        if (_textCountdown.text == "3")
        {
            CountSrc.Play("CountDown_Single");
        }
        else if (_textCountdown.text == "2")
        {
            CountSrc.Play("CountDown_Single");
        }
        else if (_textCountdown.text == "1")
        {
            CountSrc.Play("CountDown_Single");
        }
        else if (_textCountdown.text == "GO!")
        {
            CountSrc.Play("CountDown_Finish");
            BGMSrc.Play("Battle");
        }
    }

    public static int GetGamemode()
    {
        return GameChange;
    }
}