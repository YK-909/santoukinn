using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    public Button FirstSelectButton;
    private GameObject Button;


    // Start is called before the first frame update
    void Start()
    {
        FirstSelectButton.Select();
        Button = GameObject.Find("Button");
    }

    // Update is called once per frame
    void Update()
    { 
        
    }
}
