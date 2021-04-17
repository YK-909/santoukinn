using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScene: MonoBehaviour
{
    public SceneObject m_BackScene;

     public void LoadSceneBottun()
    {
            SceneManager.LoadScene(m_BackScene);
        
    }
}