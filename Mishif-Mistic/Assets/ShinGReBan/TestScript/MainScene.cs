using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    public GameObject[] GameObjectsTohidden;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneUnloaded += OnSceneUnloaded;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OputionButton()
    {
        foreach(GameObject obj in GameObjectsTohidden)
        {
            obj.SetActive(false);
        }

        SceneManager.LoadScene("OptionScene", LoadSceneMode.Additive);
    }

    private void OnSceneUnloaded(Scene current)
    {
        foreach(GameObject obj in GameObjectsTohidden)
        {
            obj.SetActive(true);
        }
    }
}
