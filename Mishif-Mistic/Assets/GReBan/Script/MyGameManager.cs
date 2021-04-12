using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelectCharacter
{
    public class MyGameManager : MonoBehaviour
    {
        private static MyGameManager myGameManager;
        //ゲーム全体管理データ
        [SerializeField]
        private MyGameManagerData myGameManagerData = null;

        private void Awake()
        {
            //MyGameManagerにする処理
            if(myGameManager == null)
            {
                myGameManager = this;
                DontDestroyOnLoad(this);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        //MyGameManagerDateを返す
        public MyGameManagerData GetMyGameManagerData()
        {
            return myGameManagerData;
        }
    }
}
