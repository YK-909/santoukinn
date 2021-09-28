using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause_Button : MonoBehaviour
{
    public SceneObject BackScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadSceneButtun()
    {
        SceneManager.LoadScene(BackScene);

        //音鳴らす
        //audioSource.PlayOneShot(TitleDecesionSound);

    }
}
