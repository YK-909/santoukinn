using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class LoadScene: MonoBehaviour
{
    public SceneObject m_BackScene;

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
        if (Input.GetKeyDown(KeyCode.Backspace))
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
}