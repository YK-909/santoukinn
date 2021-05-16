using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SelectCharacter
{
    public class SceneTransition : MonoBehaviour
    {
        public AudioClip DecesionSound;
        AudioSource audioSource;

        private MyGameManagerData myGameManagerData;

        // Start is called before the first frame update
        void Start()
        {
            myGameManagerData = FindObjectOfType<MyGameManager>().GetMyGameManagerData();

            //Componentを取得
            audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void GoToOtherScene()
        {
            
            //キャラクター選択のシーンに移動
            SceneManager.LoadScene("SelectCharactor");
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

            audioSource.PlayOneShot(DecesionSound);

            Invoke("GoToOtherScene", 2.0f);
        }
    }
}
