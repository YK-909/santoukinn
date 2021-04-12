using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SelectCharacter
{
    [CreateAssetMenu(fileName = "MyGameManagerData", menuName = "MyGameManagerData")]
    public class MyGameManagerData : ScriptableObject
    {
        //次のシーンの名前
        [SerializeField]
        private string nextSceneName;
        //使用するキメラのプレハブ
        [SerializeField]
        private GameObject character;
        //データ初期化
        private void OnEnable()
        {
            //タイトルシーン時にリセット
            if (SceneManager.GetActiveScene().name == "SelectCharactorTitle")
            {
                nextSceneName = "";
                character = null;
            }
        }

        public void SetNextSceneName(string nextSceneName)
        {
            this.nextSceneName = nextSceneName;
        }

        public string GetNextSceneName()
        {
            return nextSceneName;
        }

        public void SetCharactor(GameObject charactor)
        {
            this.character = charactor;
        }

        public GameObject GetCharactor()
        {
            return character;
        }
    }
}
