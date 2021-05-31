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
        //public AudioClip CharacterDecesion;
        //AudioSource audioSource;


        // Start is called before the first frame update
        void Start()
        {
            sceneTransition = FindObjectOfType<SceneTransition>();

            //AudioComponent取得
            //audioSource = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        void Update()
        {
            if (ContloleLeg.leg == 1)
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                this.gameObject.SetActive(true);
            }

            if(ContloleLeg2.leg2 == 1)
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                this.gameObject.SetActive(true);
            }
        }

        public void OnGameStart()
        {
            //音鳴らす
            //audioSource.PlayOneShot(CharacterDecesion);

            Invoke("OnGameStart2", 2.0f);
        }

        public void OnGameStart2()
        {
            //MyGameManagerDateに保存されている次のシーンに移動
            sceneTransition.GameStart();
        }
    }
}
