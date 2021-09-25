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

    //AuidoComponent設定
    //public AudioClip TitleDecesionSound;
    //AudioSource audioSource;

    public void Start()
    {
        //Componentを取得
        //audioSource = GetComponent<AudioSource>();
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

        head = 0;
        body = 0;
        leg = 0;
        passive = 0;
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