using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SelectCharacter
{
    public class SceneTransition : MonoBehaviour
    {
        private MyGameManagerData myGameManagerData;

        // Start is called before the first frame update
        void Start()
        {
            myGameManagerData = FindObjectOfType<MyGameManager>().GetMyGameManagerData();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void GoToOtherScene(string stage)
        {
            //次のシーンをMyGameManagerに保存
            myGameManagerData.SetNextSceneName(stage);
            //キャラクター選択のシーンに移動
            SceneManager.LoadScene("SelectCharactor");
        }

        public void GameStart()
        {
            //　MyGameManagerDataに保存されている次のシーンに移動する
            SceneManager.LoadScene(myGameManagerData.GetNextSceneName());
        }
    }
}
