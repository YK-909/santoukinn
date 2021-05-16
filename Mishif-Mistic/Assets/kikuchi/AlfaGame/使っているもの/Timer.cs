using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public float Second;
    private int Secondtext;
    private int hour;

    // Start is called before the first frame update
    void Start()
    {
        //timerText = GetComponent();
    }

    // Update is called once per frame
    void Update()
    {
        Second -= Time.deltaTime;


        if (Second <= 0f)
        {
            //シーン変更
            //SceneManager.LoadScene("ResultScene");
        }
        TimerText.text = Second.ToString("f0");
    }
}