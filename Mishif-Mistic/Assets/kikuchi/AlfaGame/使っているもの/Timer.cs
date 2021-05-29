using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    private  float Second=180;
    [SerializeField]
    private Text _textCountdown;
    public static int GameChange;
    [SerializeField]
    private Text GameWinner;


    // Start is called before the first frame update
    void Start()
    {
        _textCountdown.text = "";
        GameWinner.text = "";
        StartCoroutine(CountdownCoroutine());
    }

    IEnumerator CountdownCoroutine()
    {
        _textCountdown.gameObject.SetActive(true);

        _textCountdown.text = "3";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "2";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "1";
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
        
            }
            else if (KeybordPlay2.GetP2HP() <= 0)
            {
                GameWinner.text = "P1の勝利";
                GameChange = 2;
             
            }
            //制限時間による勝敗
            if (Second <= 0)
            {
                if (JoyconPlay1.GetP1HP() < KeybordPlay2.GetP2HP())
                {
                    GameWinner.text = "P2の勝利";
                    GameChange = 2;
               
                }
                else if (KeybordPlay2.GetP2HP() < JoyconPlay1.GetP1HP())
                {
                    GameWinner.text = "P1の勝利";
                    GameChange = 2;
               
                }
            }
        }
    }

    public static int GetGamemode()
    {
        return GameChange;
    }
}