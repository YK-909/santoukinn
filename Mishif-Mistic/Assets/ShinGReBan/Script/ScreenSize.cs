using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FullScreen()
    {
        Screen.SetResolution(Screen.width, Screen.height, true);
    }

    public void Window()
    {
        Screen.SetResolution(1280, 720, false);
    }
}
