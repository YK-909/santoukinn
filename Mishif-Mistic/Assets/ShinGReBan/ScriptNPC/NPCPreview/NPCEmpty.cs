using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCEmpty : MonoBehaviour
{
    [SerializeField]
    int Head;
    [SerializeField]
    int Body;
    [SerializeField]
    int Leg;
    [SerializeField]
    int Passive;

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
            if (LoadScene.head == 4 && LoadScene.body == Body && LoadScene.leg == Leg && LoadScene.passive == 4)
            {
                //if文の外でやると無駄に毎フレーム実行されるので中にする
                GameObject obj = (GameObject)Resources.Load("CP1Kimera" + Head + Body + Leg + Passive);

                //メンバ変数に入れる
                instance = (GameObject)Instantiate(obj, new Vector3(4.27f, 1.17f, 7.64f), Quaternion.Euler(0f, 90f, 0f));
                One = false;
            }
        }
        else
        {
            instance.SetActive(false);
        }
        if (LoadScene.head == 4 && LoadScene.body == Body && LoadScene.leg == Leg && LoadScene.passive == 4)
        {
            instance.SetActive(true);
            instance.transform.RotateAround(new Vector3(4.27f, 1.17f, 7.64f), transform.up, 20 * Time.deltaTime);
        }
    }
}
