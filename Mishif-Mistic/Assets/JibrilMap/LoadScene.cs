﻿using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
//using UnityEngine;

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

    public void LoadSceneBottun()
    {
            SceneManager.LoadScene(m_BackScene);

        //音鳴らす
        //audioSource.PlayOneShot(TitleDecesionSound);

    }
}