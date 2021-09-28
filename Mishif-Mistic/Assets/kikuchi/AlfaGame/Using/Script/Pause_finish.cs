using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause_finish : MonoBehaviour
{
    public GameObject PauseUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Pausefinish()
    {
        PauseUI.SetActive(false);
    }
}
