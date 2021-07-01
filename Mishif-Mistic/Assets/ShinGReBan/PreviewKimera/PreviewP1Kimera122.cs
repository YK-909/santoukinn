using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewP1Kimera122 : MonoBehaviour
{
    [SerializeField]
    int Head;
    [SerializeField]
    int Body;
    [SerializeField]
    int Leg;

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
            if (Contlole.head == Head && ContloleBody.body == Body && ContloleLeg.leg == Leg)
            {
                //if文の外でやると無駄に毎フレーム実行されるので中にする
                GameObject obj = (GameObject)Resources.Load("CP1Kimera122");
                //メンバ変数に入れる
                instance = (GameObject)Instantiate(obj, new Vector3(-4.52f, -1.09f, 10.0f), Quaternion.Euler(0f, 90f, 0f));
                One = false;
            }
        }
        else
        {
            instance.SetActive(false);
        }

        if (Contlole.head == Head && ContloleBody.body == Body && ContloleLeg.leg == Leg)
        {
            instance.SetActive(true);
            instance.transform.RotateAround(new Vector3(-4.8f, -1, 10), transform.up, 20 * Time.deltaTime);
        }
    }
}
