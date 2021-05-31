using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SelectCharacter
{
    public class GameStartButton : MonoBehaviour
    {
        private SceneTransition sceneTransition;


        // Start is called before the first frame update
        void Start()
        {
            sceneTransition = FindObjectOfType<SceneTransition>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnGameStart()
        {
            Invoke("OnGameStart2", 2.0f);
        }

        public void OnGameStart2()
        {
            //MyGameManagerDateに保存されている次のシーンに移動
            sceneTransition.GameStart();
        }
    }
}
