using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LoadScene: MonoBehaviour
{
    public SceneObject m_BackScene;
    public GameObject NPCCanvas;
    public GameObject SelectCanvas1;
    public GameObject SelectCanvas2;
    public GameObject SelectCanvas3;
    public GameObject Kimera1;
    public GameObject Kimera2;
    public GameObject Kimera3;
    public GameObject Stand;

    public static int head;
    public static int body;
    public static int leg;
    public static int passive;

    GameObject instance;

    bool One;

    //AuidoComponent設定
    //public AudioClip TitleDecesionSound;
    //AudioSource audioSource;

    public void Start()
    {
        //Componentを取得
        //audioSource = GetComponent<AudioSource>();

        One = true;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Invoke("InvokeTitle", 1.0f);
        }
    }

    public void LoadSceneBottun()
    {
        SceneManager.LoadScene(m_BackScene);

        
        //音鳴らす
        //audioSource.PlayOneShot(TitleDecesionSound);

    }

    public void InvokeTitle()
    {
        SceneManager.LoadScene(m_BackScene);
    }

    public void LoadSceneButtonTitle()
    {
        Invoke("InvokeTitle", 1.0f);
    }

    public void NPCBack()
    {
        NPCCanvas.SetActive(true);
        SelectCanvas1.SetActive(false);
        Kimera1.SetActive(true);
        Kimera2.SetActive(true);
        Kimera3.SetActive(true);
        Stand.SetActive(false);

        Destroy(instance);

        head = 4;
        body = 4;
        leg = 4;
        passive = 4;

        if (One)
        {
            if (LoadScene.head == 4 && LoadScene.body == 4 && LoadScene.leg == 4 && LoadScene.passive == 4)
            {
                //if文の外でやると無駄に毎フレーム実行されるので中にする
                GameObject obj = (GameObject)Resources.Load("CP1Kimera4444");

                //メンバ変数に入れる
                instance = (GameObject)Instantiate(obj, new Vector3(4.27f, 1.17f, 7.64f), Quaternion.Euler(0f, 90f, 0f));
                One = false;
            }
        }
        else
        {
            instance.SetActive(false);
        }
        if (LoadScene.head == 4 && LoadScene.body == 4 && LoadScene.leg == 4 && LoadScene.passive == 4)
        {
            instance.SetActive(true);
            instance.transform.RotateAround(new Vector3(4.27f, 1.17f, 7.64f), transform.up, 20 * Time.deltaTime);
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

    public static int GetPassive()
    {
        return passive;
    }
}