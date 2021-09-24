using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyButton : MonoBehaviour
{
    public GameObject StartCanvas;
    public GameObject SecondCanvas;

    // Start is called before the first frame update
    void Start()
    {
        StartCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressButton()
    {
        StartCanvas.SetActive(false);
        SecondCanvas.SetActive(true);
    }
}
