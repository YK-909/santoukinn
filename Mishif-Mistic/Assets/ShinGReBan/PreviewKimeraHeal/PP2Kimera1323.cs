using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PP2Kimera1323 : MonoBehaviour
{
    [SerializeField]
    int Head2;
    [SerializeField]
    int Body2;
    [SerializeField]
    int Leg2;
    [SerializeField]
    int Passive2;

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
            if (Contlole2.head2 == Head2 && ContloleBody2.body2 == Body2 && ContloleLeg2.leg2 == Leg2 && ContlolePassive2.passive2 == Passive2)
            {
                //if文の外でやると無駄に毎フレーム実行されるので中にする
                GameObject obj = (GameObject)Resources.Load("CP1Kimera1323");
                //メンバ変数に入れる
                instance = (GameObject)Instantiate(obj, new Vector3(4.46f, -1.09f, 10.0f), Quaternion.Euler(0f, -90f, 0f));
                One = false;
            }
        }
        else
        {
            instance.SetActive(false);
        }

        if (Contlole2.head2 == Head2 && ContloleBody2.body2 == Body2 && ContloleLeg2.leg2 == Leg2 && ContlolePassive2.passive2 == Passive2)
        {
            instance.SetActive(true);
            instance.transform.RotateAround(new Vector3(4.8f, -1, 10), -transform.up, 20 * Time.deltaTime);
        }
    }
}
