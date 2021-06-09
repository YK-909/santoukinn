using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SelectCharacter
{
    public class NPCSceneTransition : MonoBehaviour
    {
        private MyGameManagerData myGameManagerData;

        // Start is called before the first frame update
        void Start()
        {
            //Componentを取得
            //audioSource = GetComponent<AudioSource>();

            myGameManagerData = FindObjectOfType<MyGameManager>().GetMyGameManagerData();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void GoToOtherScene()
        {
            //キャラクター選択のシーンに移動
            SceneManager.LoadScene("NPCSelectCharactor");
        }

        public void GameStart()
        {
            //　MyGameManagerDataに保存されている次のシーンに移動する
            SceneManager.LoadScene(myGameManagerData.GetNextSceneName());
        }

        public void OnStageButton(string stage)
        {
            //次のシーンをMyGameManagerに保存
            myGameManagerData.SetNextSceneName(stage);

            //音鳴らす
            //audioSource.PlayOneShot(DecesionSound);

            Invoke("GoToOtherScene", 1.0f);
        }
    }
}
