using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SelectCharacter
{
    public class ChooseCharacter : MonoBehaviour
    {
        private MyGameManagerData myGameManagerData;
        private GameObject gameStartButton;

        // Start is called before the first frame update
        void Start()
        {
            //MyGameManagerからMyGameManagerDateを取得
            myGameManagerData = FindObjectOfType<MyGameManager>().GetMyGameManagerData();
            //ゲームスタートボタン取得
            gameStartButton = transform.parent.Find("Button").gameObject;
            //ゲームスタートボタン無効
            gameStartButton.SetActive(false);
        }

        //　キャラクターを選択した時に実行しキャラクターデータをMyGameManagerDataにセット
        public void OnSelectCharacter(GameObject character)
        {
            //　ボタンの選択状態を解除して選択したボタンのハイライト表示を可能にする為に実行
            EventSystem.current.SetSelectedGameObject(null);
            //　MyGameManagerDataにキャラクターデータをセットする
            myGameManagerData.SetCharactor(character);
            //　ゲームスタートボタンを有効にする
            gameStartButton.SetActive(true);
        }

        //　キャラクターを選択した時に背景をオンにする
        public void SwitchButtonBackground(int buttonNumber)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                if (i == buttonNumber - 1)
                {
                    transform.GetChild(i).Find("Background").gameObject.SetActive(true);
                }
                else
                {
                    transform.GetChild(i).Find("Background").gameObject.SetActive(false);
                }
            }
        }
    }
}
