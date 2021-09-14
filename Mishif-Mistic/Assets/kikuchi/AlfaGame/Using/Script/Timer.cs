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
    [SerializeField]
    private Text BuffCountTextP1;

    private int Exterior1 = 1;
    private int Exterior2 = 1;
    //ADX設定
    public CriAtomSource CountSrc;
    public CriAtomSource BGMSrc;
    public CriAtomSource ESSrc;
    private CriAtomSource atomSource;
    string cueSheetBGM = "GardenBGM";
    string cueSheetCount = "CountDownSE";
    public string cueSheetES;

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
        ESSrc.cueSheet = cueSheetES;
        Exterior1 = ContlolePassive1.GetPassive();
        Exterior2 = ContlolePassive2.GetPassive2();
        ESSrc.Play();
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

        BuffCountTextP1.text = "";
        BuffCountTextP2.text = "";
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

                Invoke("SceneResult2", 3.0f);
            }
            else if (KeybordPlay2.GetP2HP() <= 0)
            {
                GameWinner.text = "P1の勝利";
                GameChange = 2;

                Invoke("SceneResult1", 3.0f);

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
                else if (KeyBordPlay1.GetP1HP() == BotFSW.GetP2HP())
                {
                    GameWinner.text = "引き分け";
                    GameChange = 2;

                    Invoke("SceneResultDraw", 3.0f);

                }
            }

            if (Exterior2 == 2)
            {
                string CounttextP2 = KeybordPlay2.GetBuffCountP2().ToString("0");
                BuffCountTextP2.text = "加速P2:" + CounttextP2 + "回";
            }
            else if(Exterior2==1)
            {
                string CounttextP2 = KeybordPlay2.GetPalsyCountP2().ToString("0");
                BuffCountTextP2.text = "鱗粉P2:" + CounttextP2 + "回";
            }
          

            if (Exterior1 == 2)
            {
                string CounttextP1 = JoyconPlay1.GetBuffCountP1().ToString("0");
                BuffCountTextP1.text = "加速P1:" + CounttextP1 + "回";
            }
            else if (Exterior1 == 1)
            {
                string CounttextP1 = JoyconPlay1.GetPalsyCountP1().ToString("0");
                BuffCountTextP1.text = "鱗粉P1:" + CounttextP1 + "回";
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
            BGMSrc.Play();
            
        }

        if (KeybordPlay2.GetP2HP() <= 0)
        {
            BGMSrc.Stop();
            ESSrc.Stop();
        }
        else if (JoyconPlay1.GetP1HP() <= 0)
        {
            BGMSrc.Stop();
            ESSrc.Stop();
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

    void SceneResultDraw()
    {
        SceneManager.LoadScene("ResultSceneDraw");
    }
}