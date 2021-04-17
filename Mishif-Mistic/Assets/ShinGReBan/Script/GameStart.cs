using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelectCharacter
{
    public class GameStart : MonoBehaviour
    {
        private MyGameManagerData myGameManagerData;

        // Start is called before the first frame update
        void Start()
        {
            myGameManagerData = FindObjectOfType<MyGameManager>().GetMyGameManagerData();
            Instantiate(myGameManagerData.GetCharactor(), Vector3.zero, Quaternion.identity);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
