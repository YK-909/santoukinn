using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    [SerializeField] public Text ReadyGo; //実行と同時に表示されるテキストの変数
    [SerializeField] public P1Controller P1; //プレイヤー1のスクリプト変数
    [SerializeField] public P2Controller P2; //プレイヤー2のスクリプト変数

    // Start is called before the first frame update
    void Start()
    {
        //スタートと同時にReadyCoroutineを実行
        StartCoroutine(ReadyCoroutine()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart()
    {
        //ClearSceneへ遷移
        SceneManager.LoadScene("ClearScene");
    }

    public void Alchemy()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("ClearScene");
    }

    //スタートシーンから切り替わるとReadyGoを表示
    IEnumerator ReadyCoroutine()
    {
        P1.enabled = false; //P1を無効化する
        P2.enabled = false; //P2を無効化する
        yield return new WaitForSeconds(0.5f); //0.5秒待つ

        ReadyGo.gameObject.SetActive(true); //ReadyGoテキストを表示する

        ReadyGo.text = "Ready?"; //Readyと表示する
        yield return new WaitForSeconds(1.5f); //1.5秒待つ

        ReadyGo.text = "Go!"; //Goと表示する
        yield return new WaitForSeconds(1.0f); //1.0秒待つ

        ReadyGo.gameObject.SetActive(false); //ReadyGoテキストを非表示にする
        P1.enabled = true; //P1を有効化する
        P2.enabled = true; //P2を有効化する
    }
}
