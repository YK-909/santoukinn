using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SelectCharacter
{
    public class Kimera121 : MonoBehaviour
    {
        [SerializeField]
        int Head;
        [SerializeField]
        int Body;
        [SerializeField]
        int Leg;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Contlole.GetHead() == 1 && ContloleBody.GetBody() == 2 && ContloleLeg.GetLeg() == 1)
            {
                this.gameObject.SetActive(true);
            }
            else
            {
                this.gameObject.SetActive(false);
            }
        }
    }
}
