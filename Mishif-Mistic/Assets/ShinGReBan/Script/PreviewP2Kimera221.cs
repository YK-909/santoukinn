using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewP2Kimera221 : MonoBehaviour
{
    [SerializeField]
    int Head2;
    [SerializeField]
    int Body2;
    [SerializeField]
    int Leg2;

    GameObject instance;

    bool One;

    // Start is called before the first frame update
    void Start()
    {
        One = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (One)
        {
            if (Contlole2.head2 == Head2 && ContloleBody2.body2 == Body2 && ContloleLeg2.leg2 == Leg2)
            {
                //if文の外でやると無駄に毎フレーム実行されるので中にする
                GameObject obj = (GameObject)Resources.Load("CP2Kimera221");
                //メンバ変数に入れる
                instance = (GameObject)Instantiate(obj, new Vector3(3.0f, -0.5f, 0.0f), Quaternion.Euler(0f, 180f, 0f));
                One = false;
            }
        }
        else
        {
            instance.SetActive(false);
        }

        if (Contlole2.head2 == Head2 && ContloleBody2.body2 == Body2 && ContloleLeg2.leg2 == Leg2)
        {
            instance.SetActive(true);
        }
    }
}
