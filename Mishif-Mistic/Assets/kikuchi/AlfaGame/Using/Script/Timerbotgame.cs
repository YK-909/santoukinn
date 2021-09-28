using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timerbotgame : MonoBehaviour
{
    public Text TimerText;
    private float Second = 180;
    [SerializeField]
    private Text _textCountdown;
    public static int GameChange;

    private int Exterior1 = 1;

    public GameObject Para;
    public GameObject Speed;
    public GameObject Drain;


    public GameObject P1used1;
    public GameObject P1used2;
    public GameObject P1used3;

    public GameObject PauseUI;
    public GameObject SoundUI;
    //ADX設定
    public CriAtomSource CountSrc;
    public CriAtomSource BGMSrc;
    public CriAtomSource ESSrc;
    string cueSheetBGM = "GardenBGM";
    string cueSheetCount = "CountDownSE";
    public string cueSheetES;

    // Start is called before the first frame update
    void Start()
    {
        GameChange = 2;
        _textCountdown.text = "";
        StartCoroutine(CountdownCoroutine());

        Para.SetActive(false);
        Speed.SetActive(false);
        Drain.SetActive(false);
        P1used1.SetActive(false);
        P1used2.SetActive(false);
        P1used3.SetActive(false);

        //CriAtomSourceを取得
        CriAtomExAcb BGMacb = CriAtom.GetAcb(cueSheetBGM);
        CriAtomExAcb Countacb = CriAtom.GetAcb(cueSheetCount);
        Exterior1 = NPCP1ContlolePassive.GetPassive();
        BGMSrc.cueSheet = cueSheetBGM;
        CountSrc.cueSheet = cueSheetCount;
        ESSrc.cueSheet = cueSheetES;
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

        GameChange = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseUI.activeSelf && SoundUI.activeSelf == false)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameChange = 1;
                PauseUI.SetActive(false);
            }
        }
        else
        {
            if (GameChange == 1)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    GameChange = 3;
                    PauseUI.SetActive(true);
                }
            }
        }

        if (GameChange == 3)
        {
            if (PauseUI.activeSelf==false && SoundUI.activeSelf==false)
            {
                GameChange = 1;
            }
        }

        if (GameChange == 1)
        {
            Second -= Time.deltaTime;
            TimerText.text = Second.ToString("f0");

            //HPが０による勝敗
            if (KeyBordPlay1.GetP1HP() <= 0)
            {
                GameChange = 2;

                Invoke("BotSceneResultNPCWin", 3.0f);

            }
            else if (BotFSW.GetP2HP() <= 0)
            {
                GameChange = 2;

                Invoke("BotSceneResultP1Win", 3.0f);

            }
            //制限時間による勝敗
            if (Second <= 0)
            {
                if (BotFSW.GetP2HP() < KeyBordPlay1.GetP1HP())
                {
                    GameChange = 2;

                    Invoke("BotSceneResultP1Win", 3.0f);

                }
                else if (KeyBordPlay1.GetP1HP() < BotFSW.GetP2HP())
                {
                    GameChange = 2;

                    Invoke("BotSceneResultNPCWin", 3.0f);

                }
                else if (KeyBordPlay1.GetP1HP() == BotFSW.GetP2HP())
                {
                    GameChange = 2;

                    Invoke("BotSceneResultDraw", 3.0f);

                }
            }

            if (Exterior1 == 3)
            {
                Drain.SetActive(true);
            }
            else if (Exterior1 == 2)
            {
                int CountP1 = KeyBordPlay1.GetBuffCountP1();
                Speed.SetActive(true);
                if (CountP1 == 2)
                {
                    P1used1.SetActive(true);
                }
                else if (CountP1 == 1)
                {
                    P1used2.SetActive(true);
                }
                else if (CountP1 == 0)
                {
                    P1used3.SetActive(true);
                }
            }
            else if (Exterior1 == 1)
            {
                int CountP1 = KeyBordPlay1.GetPalsyCountP1();
                Para.SetActive(true);
                if (CountP1 == 2)
                {
                    P1used1.SetActive(true);
                }
                else if (CountP1 == 1)
                {
                    P1used2.SetActive(true);
                }
                else if (CountP1 == 0)
                {
                    P1used3.SetActive(true);
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

        if (KeyBordPlay1.GetP1HP() <= 0)
        {
            BGMSrc.Stop();
            ESSrc.Stop();
        }
        else if (BotFSW.GetP2HP() <= 0)
        {
            BGMSrc.Stop();
            ESSrc.Stop();
        }
    }

    public static int GetGamemode()
    {
        return GameChange;
    }

    void BotSceneResultP1Win()
    {
        SceneManager.LoadScene("NPCResultSceneP1Win");
    }

    void BotSceneResultNPCWin()
    {
        SceneManager.LoadScene("NPCResultSceneNPCWin");
    }

    void BotSceneResultDraw()
    {
        SceneManager.LoadScene("ResultSceneDraw");
    }
}