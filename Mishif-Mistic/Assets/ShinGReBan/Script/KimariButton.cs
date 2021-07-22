using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KimariButton : MonoBehaviour
{
    public GameObject Area1;
    public GameObject P1text;

    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void KimeraButton1()
    {
        this.gameObject.SetActive(false);
        Area1.SetActive(false);
        P1text.SetActive(true);
    }
}
