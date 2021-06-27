using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour
{
    public Button FirstSelectButton;

    // Start is called before the first frame update
    void Start()
    {
        FirstSelectButton.Select();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
