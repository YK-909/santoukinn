using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class LoadScene: MonoBehaviour
{
    public SceneObject m_BackScene;

    public void LoadSceneBottun()
    {
        SceneManager.LoadScene(m_BackScene);
    }

    public void OnLoadScene()
    {
        Invoke("LoadSceneBottun", 1.0f);
    }
}