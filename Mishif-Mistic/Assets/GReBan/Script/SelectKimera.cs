using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SelectCharacter
{
    public class SelectKimera : MonoBehaviour
    {
        public static int head;
        public static int body;
        public static int leg;
        

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ButtonClick()
        {
            switch (transform.name)
            {
                case "CharacterButton1":
                    head = 1;
                    //Debug.Log("押された1");
                    break;

                case "CharacterButton2":
                    head = 2;
                    //Debug.Log("押された2");
                    break;

                case "CharacterButton3":
                    head = 3;
                    //Debug.Log("押された3");
                    break;

                case "CharacterButton4":
                    body = 1;
                    //Debug.Log("押された3");
                    break;

                case "CharacterButton5":
                    body = 2;
                    //Debug.Log("押された3");
                    break;

                case "CharacterButton6":
                    body = 3;
                    //Debug.Log("押された3");
                    break;

                case "CharacterButton7":
                    leg = 1;
                    //Debug.Log("押された3");
                    break;

                case "CharacterButton8":
                    leg = 2;
                    //Debug.Log("押された3");
                    break;

                case "CharacterButton9":
                    leg = 3;
                    //Debug.Log("押された3");
                    break;
                default:
                    break;
            }
        }

        public static int GetHead()
        {
            return head;
        }

        public static int GetBody()
        {
            return body;
        }

        public static int GetLeg()
        {
            return leg;
        }
    }
}
