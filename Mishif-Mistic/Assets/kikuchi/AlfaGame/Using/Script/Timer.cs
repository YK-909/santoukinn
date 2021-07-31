using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    private  float Second=180;
    [SerializeField]
    private Text _textCountdown;
    public static int GameChange;
    [SerializeField]
    private Text GameWinner;
    [SerializeField]
    private Text BuffCountTextP2;

    //ADX設定
    public CriAtomSource CountSrc;
    public CriAtomSource BGMSrc;
    public CriAtomSource WastelandES01;
    private CriAtomSource atomSource;
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
            if (JoyconPlay1.GetP1HP() <= 0)
            {
                GameWinner.text = "P2の勝利";
                GameChange = 2;

                Invoke("SceneResult2", 2.0f);
            }
            else if (KeybordPlay2.GetP2HP() <= 0)
            {
                GameWinner.text = "P1の勝利";
                GameChange = 2;

                Invoke("SceneResult1", 2.0f);

            }
            //制限時間による勝敗
            if (Second <= 0)
            {
                if (JoyconPlay1.GetP1HP() < KeybordPlay2.GetP2HP())
                {
                    GameWinner.text = "P2の勝利";
                    GameChange = 2;

                    Invoke("SceneResult2", 2.0f);

                }
                else if (KeybordPlay2.GetP2HP() < JoyconPlay1.GetP1HP())
                {
                    GameWinner.text = "P1の勝利";
                    GameChange = 2;

                    Invoke("SceneResult1", 2.0f);
                }
            }
            string Counttext = KeybordPlay2.BuffCountP2().ToString("0");
            BuffCountTextP2.text ="P2="+Counttext;
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
            atomSource.Play("Wind01");
        }
    }

    public static int GetGamemode()
    {
        return GameChange;
    }

    void SceneResult1()
    {
        SceneManager.LoadScene("ResultSceneP1Win");
    }

    void SceneResult2()
    {
        SceneManager.LoadScene("ResultSceneP2Win");
    }
}