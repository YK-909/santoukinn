using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WazaSelectButton : MonoBehaviour
{
    public GameObject AllCanvas;
    public GameObject SelectCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectClick()
    {
        AllCanvas.SetActive(false);
        SelectCanvas.SetActive(true);
    }
}
