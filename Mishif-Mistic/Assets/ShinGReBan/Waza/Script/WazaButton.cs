using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WazaButton : MonoBehaviour
{
    public GameObject LeftButton;
    public GameObject RightButton;
    public GameObject Back;
    public GameObject AllCanvas;
    public GameObject SelectCanvas;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AllCanvas.SetActive(true);
            Back.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            LeftButton.SetActive(true);
            SelectCanvas.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            RightButton.SetActive(true);
            SelectCanvas.SetActive(false);
        }
    }
}
