using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButtonContlole : MonoBehaviour
{
    public GameObject KimeraButton1;
    public GameObject KimeraButton2;
    public GameObject KButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (KimeraButton1.activeSelf)
        {
            KButton.SetActive(false);
        }
        else if (KimeraButton2.activeSelf)
        {
            KButton.SetActive(false);
        }
        else
        {
            KButton.SetActive(true);
        }
    }
}
