using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SelectCharacter
{
    public class GameStartButton : MonoBehaviour
    {
        private SceneTransition sceneTransition;

        //AudioComponent
        public AudioClip CharacterDecesion;
        AudioSource audioSource;


        // Start is called before the first frame update
        void Start()
        {
            sceneTransition = FindObjectOfType<SceneTransition>();

            //AudioComponent取得
            audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void OnGameStart()
        {
            //MyGameManagerDateに保存されている次のシーンに移動
            sceneTransition.GameStart();

            //音鳴らす
            audioSource.PlayOneShot(CharacterDecesion);
        }
    }
}
